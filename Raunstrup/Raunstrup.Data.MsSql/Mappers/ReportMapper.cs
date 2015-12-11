using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Ghost;
using Raunstrup.Data.MsSql.Proxies;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class ReportMapper
    {
        private readonly DataContext _context;
        
        public ReportMapper(DataContext context)
        {
            _context = context;
        }
        
        public Report Get(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                var command = connection.CreateCommand();
                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = id;

                command.Parameters.Add(idParam);

                var fields = new[]
                {
                     "r.ReportId",
                     "r.[Date]",
                     "r.ProjectId",
                     "r.EmployeeId",
                     "rl.Quantity",
                     "rl.ProductId"
                };

                var query = new[]
                {
                    "SELECT " + string.Join(",", fields),
                    "FROM Report r",
                    "JOIN ReportLine rl ON rl.ReportId = r.ReportId"
                };

                command.CommandText = string.Join(" ", query);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return Map(reader);
                }
            }
        }

        public IList<Report> GetAll()
        {
            using (var connection = _context.CreateConnection())
            {
                var command = connection.CreateCommand();
                
                var fields = new[]
                {
                     "r.ReportId",
                     "r.[Date]",
                     "r.ProjectId",
                     "r.EmployeeId",
                     "rl.Quantity",
                     "rl.ProductId"
                };

                var query = new[]
                {
                    "SELECT " + string.Join(",", fields),
                    "FROM Report r",
                    "JOIN ReportLine rl ON rl.ReportId = r.ReportId",
                    "ORDER BY r.ReportId"
                };

                command.CommandText = string.Join(" ", query);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return MapAll(reader);
                }
            }
        }

        public void Insert(Report report)
        {
            using (var connection = _context.CreateConnection())
            using (var reportInsert = connection.CreateCommand())
            using (var reportLinesInsert = connection.CreateCommand())
            {
                reportInsert.CommandText = @"INSERT INTO Report ([Date], ProjectId, EmployeeId) 
                                             VALUES (@date, @projectId, @employeeId); 
                                             SELECT CAST(SCOPE_IDENTITY() AS INT);";

                //var reportInsertBuilder = new InsertCommandBuilder("Report");

                //reportInsertBuilder
                //    .Field("Date", DbType.Int32)
                //    .Field("ProjectId", DbType.Int32)
                //    .Field("EmployeeId", DbType.Int32)
                //    .Values(report.Date, report.Project.Id, report.Employee.Id);

                var dateParam = reportInsert.CreateParameter();
                var projectIdParameter = reportInsert.CreateParameter();
                var employeeIdParameter = reportInsert.CreateParameter();

                dateParam.ParameterName = "@date";
                dateParam.Value = report.Date;
                dateParam.DbType = DbType.Date;

                projectIdParameter.ParameterName = "@projectId";
                projectIdParameter.Value = report.Project.Id;
                projectIdParameter.DbType = DbType.Int32;

                employeeIdParameter.ParameterName = "@employeeId";
                employeeIdParameter.Value = report.Employee.Id;
                employeeIdParameter.DbType = DbType.Int32;

                reportInsert.Parameters.Add(dateParam);
                reportInsert.Parameters.Add(projectIdParameter);
                reportInsert.Parameters.Add(employeeIdParameter);

                reportLinesInsert.CommandText = "INSERT INTO ReportLine (Quantity, ProductId, ReportId) VALUES ";

                //var reportLinesBuilder = new InsertCommandBuilder("ReportLine");

                //reportLinesBuilder
                //    .Field("Quantity", DbType.Int32)
                //    .Field("ReportId", DbType.Int32)
                //    .Field("ProductId", DbType.Int32);

                //foreach (var reportLine in report.Lines)
                //{
                //    reportLinesBuilder.Values(reportLine.Quantity, 1, reportLine.Item.Id);
                //}

                // TODO: Make this re-usable
                var names = new List<string>();

                for (var i = 0; i < report.Lines.Count; i++)
                {
                    var quantityParam = reportLinesInsert.CreateParameter();

                    quantityParam.ParameterName = "@quantity_" + i;
                    quantityParam.Value = report.Lines[i].Quantity;
                    quantityParam.DbType = DbType.Int32;

                    var productIdParameter = reportLinesInsert.CreateParameter();

                    productIdParameter.ParameterName = "@productId_" + i;
                    productIdParameter.Value = report.Lines[i].Item.Id;
                    productIdParameter.DbType = DbType.Int32;

                    reportLinesInsert.Parameters.Add(quantityParam);
                    reportLinesInsert.Parameters.Add(productIdParameter);

                    names.Add(string.Format("({0}, {1}, @reportId)", quantityParam.ParameterName, productIdParameter.ParameterName));
                }

                var reportIdParameter = reportLinesInsert.CreateParameter();

                reportIdParameter.ParameterName = "@reportId";
                reportIdParameter.DbType = DbType.Int32;

                reportLinesInsert.Parameters.Add(reportIdParameter);
                reportLinesInsert.CommandText += string.Join(", ", names);

                connection.Open();
                reportInsert.Prepare();
                reportLinesInsert.Prepare();
                
                using (var transaction = connection.BeginTransaction())
                //using (var reportInsert = reportInsertBuilder.Build(connection.CreateCommand))
                //using (var reportLinesInsert = reportInsertBuilder.Build(connection.CreateCommand))
                {
                    reportInsert.Transaction = transaction;
                    reportLinesInsert.Transaction = transaction;

                    reportIdParameter.Value = reportInsert.ExecuteScalar();

                    reportLinesInsert.ExecuteNonQuery();
                    transaction.Commit();

                    report.Id = (int) reportIdParameter.Value;
                }
            }
        }

        public void Update(Report report)
        {
            using (var connection = _context.CreateConnection())
            using (var update = connection.CreateCommand())
            using (var tempCreate = connection.CreateCommand())
            using (var tempInsert = connection.CreateCommand())
            using (var merge = connection.CreateCommand())
            {
                update.CommandText = @"UPDATE Report SET
                                         [Date]=@date, ProjectId=@projectId, EmployeeId=@employeeId)
                                       WHERE ReportId=@id";
                
                var idParam = update.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = report.Id;
                idParam.DbType = DbType.Int32;

                update.Parameters.Add(idParam);

                SetParameters(update, report);

                tempCreate.CommandText = @"CREATE TABLE #TempReportLine 
                                           (ReportLineId int, Quantity int, ProductId int);";

                tempInsert.CommandText = @"INSERT INTO #TempReportLine (ReportLineId, Quantity, ProductId)
                                           VALUES ";

                var reportIdParameter = tempInsert.CreateParameter();

                reportIdParameter.ParameterName = "@reportId";
                reportIdParameter.Value = report.Id;
                reportIdParameter.DbType = DbType.Int32;

                tempInsert.Parameters.Add(reportIdParameter);

                var names = new List<string>();

                for (var i = 0; i < report.Lines.Count; i++)
                {
                    var quantityParam = tempInsert.CreateParameter();

                    quantityParam.ParameterName = "@quantity_" + i;
                    quantityParam.Value = report.Lines[i].Quantity;
                    quantityParam.DbType = DbType.Int32;

                    var productIdParameter = tempInsert.CreateParameter();

                    productIdParameter.ParameterName = "@productId_" + i;
                    productIdParameter.Value = report.Lines[i].Item.Id;
                    productIdParameter.DbType = DbType.Int32;

                    tempInsert.Parameters.Add(quantityParam);
                    tempInsert.Parameters.Add(productIdParameter);

                    names.Add(string.Format("({0}, {1}, @reportId)", quantityParam.ParameterName, productIdParameter.ParameterName));
                }

                tempInsert.CommandText += string.Join(", ", names);
                
                merge.CommandText = @"MERGE INTO ReportLine AS t
                                      USING #TempReportLine AS s
                                      ON t.ReportLineId = s.ReportLineId
                                      WHEN MATCHED THEN 
                                        UPDATE SET t.Quantity=s.Quantity
                                      WHEN NOT MATCHED BY TARGET THEN 
                                        INSERT (Quantity, ProductId, ReportId) 
                                        VALUES (s.Quantity, s.ProductId, s.ReportId)
                                      WHEN NOT MATCHED BY SOURCE THEN DELETE;";

                connection.Open();
                update.Prepare();
                tempInsert.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    update.Transaction = transaction;
                    tempCreate.Transaction = transaction;
                    tempInsert.Transaction = transaction;
                    merge.Transaction = transaction;

                    update.ExecuteNonQuery();
                    tempCreate.ExecuteNonQuery();

                    // TODO: Make only executing temporary insert if needed cleaner.
                    // More smelly code!
                    if (names.Count > 0)
                    {
                        tempInsert.ExecuteNonQuery();
                    }

                    merge.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
        }

        public Report Map(IDataRecord record)
        {
            var id = (int) record["ReportId"];
            var report = new ReportGhost(
                new EmployeeProxy(_context, (int) record["EmployeeId"]), 
                new ProjectProxy(_context, (int) record["ProjectId"]),
                () => LoadReportLines(id)
            ) {
                Id = id,
                Date = (DateTime) record["Date"]
            };

            return report;
        }

        public IList<Report> MapAll(IDataReader reader)
        {
            var reports = new List<Report>();

            while (reader.Read())
            {
                reports.Add(Map(reader));
            }

            return reports;
        }

        private void SetParameters(IDbCommand command, Report report)
        {
            var dateParam = command.CreateParameter();
            var projectIdParameter = command.CreateParameter();
            var employeeIdParameter = command.CreateParameter();

            dateParam.ParameterName = "@date";
            dateParam.Value = report.Date;
            dateParam.DbType = DbType.Date;

            projectIdParameter.ParameterName = "@projectId";
            projectIdParameter.Value = report.Project.Id;
            projectIdParameter.DbType = DbType.Int32;

            employeeIdParameter.ParameterName = "@employeeId";
            employeeIdParameter.Value = report.Employee.Id;
            employeeIdParameter.DbType = DbType.Int32;

            command.Parameters.Add(dateParam);
            command.Parameters.Add(projectIdParameter);
            command.Parameters.Add(employeeIdParameter);
        }

        private IList<ReportLine> LoadReportLines(int reportId)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT Quantity, ProductId 
                                        FROM ReportLine 
                                        WHERE ReportId = @id;";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.Value = reportId;
                idParam.DbType = DbType.Int32;

                command.Parameters.Add(idParam);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return MapReportLines(reader);
                }
            }
        }

        private IList<ReportLine> MapReportLines(IDataReader reader)
        {
            var reportLines = new List<ReportLine>();

            while (reader.Read())
            {
                reportLines.Add(new ReportLine(
                    new ProductProxy(_context, (int)reader["ProductId"]), 
                    (int) reader["Quantity"])
                );
            }

            return reportLines;
        }
    }
}
