using System;
using System.Collections.Generic;
using System.Data;
using Raunstrup.Data.MsSql.Mappers;
using Raunstrup.Domain;

namespace Raunstrup.Data.MsSql.Query
{
    class ReportByDurationAndEmployeeQuery : IQuery<IList<Report>>
    {
        private readonly DateTime _start;
        private readonly DateTime _end;
        private readonly Employee _employee;

        public ReportByDurationAndEmployeeQuery(DateTime start, DateTime end, Employee employee)
        {
            _start = start;
            _end = end;
            _employee = employee;
        }

        public IList<Report> Execute(DataContext context)
        {
            using (var connection = context.CreateConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = @"SELECT * FROM Report
                                        WHERE [Date] BETWEEN @start AND @end AND EmployeeId = @employeeId";

                var startDateParam = command.CreateParameter();
                var endDateParam = command.CreateParameter();
                var employeeIdParam = command.CreateParameter();

                startDateParam.ParameterName = "@start";
                startDateParam.Value = _start;
                startDateParam.DbType = DbType.Date;

                endDateParam.ParameterName = "@end";
                endDateParam.Value = _end;
                endDateParam.DbType = DbType.Date;

                employeeIdParam.ParameterName = "@employeeId";
                employeeIdParam.Value = _employee.Id;
                employeeIdParam.DbType = DbType.Int32;

                command.Parameters.Add(startDateParam);
                command.Parameters.Add(endDateParam);
                command.Parameters.Add(employeeIdParam);

                connection.Open();
                command.Prepare();

                using (var reader = command.ExecuteReader())
                {
                    return new ReportMapper(context).MapAll(reader);
                }
            }
        }
    }
}
