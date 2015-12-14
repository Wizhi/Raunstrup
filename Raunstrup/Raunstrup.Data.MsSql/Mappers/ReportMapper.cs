using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Command;
using Raunstrup.Data.MsSql.Ghost;
using Raunstrup.Data.MsSql.Proxies;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Mappers
{
    class ReportMapper
    {
        private static readonly IDictionary<string, FieldInfo> ReportFields = new Dictionary<string, FieldInfo>
        {
            { "Id", new FieldInfo("ReportId") { DbType = DbType.Int32 } },
            { "Date", new FieldInfo("[Date]") { DbType = DbType.Date } },
            { "Project", new FieldInfo("ProjectId") { DbType = DbType.Int32 } },
            { "Employee", new FieldInfo("EmployeeId") { DbType = DbType.Int32 } }
        };
        private static readonly IDictionary<string, FieldInfo> ReportLineFields = new Dictionary<string, FieldInfo>
        {
            { "Id", new FieldInfo("ReportLineId") { DbType = DbType.Int32 } },
            { "Quantity", new FieldInfo("Quantity") { DbType = DbType.Int32 } },
            { "Report", new FieldInfo("ReportId") { DbType = DbType.Int32 } },
            { "Product", new FieldInfo("ProductId") { DbType = DbType.Int32 } }
        };

        private readonly DataContext _context;
        
        public ReportMapper(DataContext context)
        {
            _context = context;
        }
        
        public Report Get(int id)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT ReportId, [Date], ProjectId, EmployeeId
                                        FROM Report
                                        WHERE ReportId = @id;";

                var idParam = command.CreateParameter();

                idParam.ParameterName = "@id";
                idParam.DbType = DbType.Int32;
                idParam.Value = id;

                command.Parameters.Add(idParam);
                
                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public IList<Report> GetAll()
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT ReportId, [Date], ProjectId, EmployeeId
                                        FROM Report;";

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
            using (var reportInsert = new InsertCommandWrapper(connection.CreateCommand()))
            using (var reportLinesInsert = new InsertCommandWrapper(connection.CreateCommand()))
            {

                reportInsert
                    .Target("Report")
                    .Field(ReportFields["Date"])
                    .Field(ReportFields["Project"])
                    .Field(ReportFields["Employee"])
                    .Values(report.Date, report.Project.Id, report.Employee.Id)
                    .Apply();

                reportInsert.Command.CommandText += "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                IDbDataParameter reportIdParameter;

                reportLinesInsert
                    .Target("ReportLine")
                    .Field(ReportLineFields["Quantity"])
                    .Field(ReportLineFields["Product"])
                    .Static(ReportLineFields["Report"], "@reportId", out reportIdParameter);
                
                foreach (var reportLine in report.ReportLines)
                {
                    reportLinesInsert.Values(reportLine.Quantity, reportLine.Product.Id);
                }

                reportLinesInsert.Apply();

                connection.Open();
                reportInsert.Command.Prepare();
                reportLinesInsert.Command.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    reportInsert.Command.Transaction = transaction;
                    reportLinesInsert.Command.Transaction = transaction;

                    reportIdParameter.Value = reportInsert.Command.ExecuteScalar();

                    reportLinesInsert.Command.ExecuteNonQuery();
                    transaction.Commit();

                    report.Id = (int) reportIdParameter.Value;
                }
            }
        }

        public void Update(Report report)
        {
            using (var connection = _context.CreateConnection())
            using (var update = new UpdateCommandWrapper(connection.CreateCommand()))
            using (var tempCreate = connection.CreateCommand())
            using (var tempInsert = new InsertCommandWrapper(connection.CreateCommand()))
            using (var merge = connection.CreateCommand())
            {
                update
                    .Target("Report")
                    .Set(ReportFields["Date"], report.Date)
                    .Set(ReportFields["Project"], report.Project.Id)
                    .Set(ReportFields["Employee"], report.Employee.Id)
                    .Parameter(ReportFields["Id"], "@updateId", report.Id)
                    .Where("ReportId = @updateId")
                    .Apply();

                tempCreate.CommandText = @"CREATE TABLE #TempReportLine 
                                           (ReportLineId int, Quantity int, ProductId int);";
                
                tempInsert
                    .Target("#TempReportLine")
                    .Field(ReportLineFields["Id"])
                    .Field(ReportLineFields["Quantity"])
                    .Field(ReportLineFields["Product"]);
                
                foreach (var reportLine in report.ReportLines)
                {
                    tempInsert.Values(reportLine.Id, reportLine.Quantity, reportLine.Product.Id);
                }
                
                merge.CommandText = @"MERGE INTO ReportLine AS t
                                      USING #TempReportLine AS s
                                      ON t.ReportLineId = s.ReportLineId
                                      WHEN MATCHED THEN
	                                      UPDATE SET Quantity = s.Quantity
                                      WHEN NOT MATCHED BY TARGET THEN
	                                      INSERT (Quantity, ProductId, ReportId)
	                                      VALUES (s.Quantity, s.ProductId, @mergeId)
                                      WHEN NOT MATCHED BY SOURCE AND t.ReportId = @mergeId THEN DELETE;";

                var mergeIdParameter = ReportLineFields["Report"].ToParameter(merge.CreateParameter);
                
                mergeIdParameter.ParameterName = "@mergeId";
                mergeIdParameter.Value = report.Id;
                
                merge.Parameters.Add(mergeIdParameter);

                connection.Open();
                update.Command.Prepare();
                merge.Prepare();

                using (var transaction = connection.BeginTransaction())
                {
                    update.Command.Transaction = transaction;
                    tempCreate.Transaction = transaction;
                    tempInsert.Command.Transaction = transaction;
                    merge.Transaction = transaction;

                    update.Command.ExecuteNonQuery();
                    tempCreate.ExecuteNonQuery();
                    
                    if (report.ReportLines.Count > 0)
                    {
                        // We only bother to build and execute the temporary insert, if it's actually needed.
                        tempInsert.Apply();
                        tempInsert.Command.Prepare();
                        tempInsert.Command.ExecuteNonQuery();
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

        private IList<ReportLine> LoadReportLines(int reportId)
        {
            using (var connection = _context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT rl.ReportLineId, rl.Quantity, ap.*
                                        FROM ReportLine rl
                                        JOIN AllProducts ap ON ap.ProductId = rl.ProductId 
                                        WHERE rl.ReportId = @id";

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
                Product product = null;

                if (!(reader["MaterialId"] is DBNull))
                {
                    product = new Material() { CostPrice = (decimal) reader["CostPrice"] };
                }
                else if (!(reader["WorkHourId"] is DBNull))
                {
                    product = new WorkHour();
                }
                else if (!(reader["TransportId"] is DBNull))
                {
                    product = new Transport();
                }
                else
                {
                    // TODO: Handle invalid product.
                }

                product.Id = (int) reader["ProductId"];
                product.Name = (string) reader["Name"];
                product.SalesPrice = (decimal) reader["SalesPrice"];

                reportLines.Add(new ReportLine(
                    product, 
                    (int) reader["Quantity"]
                ) { Id = (int) reader["ReportLineId"] });
            }

            return reportLines;
        }
    }
}
