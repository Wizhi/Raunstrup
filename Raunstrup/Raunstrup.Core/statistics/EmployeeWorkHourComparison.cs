using System;
using System.Collections.Generic;
using System.Linq;
using Raunstrup.Core.Repositories;
using Raunstrup.Model;

namespace Raunstrup.Core.statistics
{
    class EmployeeWorkHourComparison
    {
        private readonly Employee _employee;
        private readonly TimeSpan _timeSpan;
        private readonly int _expectedHours;
        private readonly IReportRepository _repository;

        public EmployeeWorkHourComparison(Employee employee, TimeSpan timeSpan, int expectedHours, IReportRepository repository)
        {
            _employee = employee;
            _timeSpan = timeSpan;
            _expectedHours = expectedHours;
            _repository = repository;
        }

        public void Between(DateTime start, DateTime end)
        {
            var reports = _repository
                .FindByEmployee(_employee)
                .Where(r => r.Date >= start && r.Date <= end);

            /*
             * Hvor mange timer har Emil arbejdet
             * 
             */
        }

        public class Comparison
        {
            private readonly IEnumerable<Report> _reports;

            public Comparison(IEnumerable<Report> reports)
            {
                _reports = reports;
            }
        }
    }
}
