using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Core.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Core.statistics
{
    public class EmployeeStatistics
    {
        public readonly Dictionary<DateTime, int> HoursWorked = new Dictionary<DateTime, int>();
        public readonly DateTime Start;
        public readonly DateTime End;
        private readonly IReportRepository _reportRepository;
        private readonly Employee _employee;
        public EmployeeStatistics(IReportRepository reportRepository, Employee employee, DateTime start, DateTime end)
        {
            Start = start.Date;
            End = start.Date;
            _reportRepository = reportRepository;
            _employee = employee;
            if (Start.CompareTo(End) < 0)
            {
                //Needs to check that start date is earlier than end enddate;
            }
            setupDictionary();
        }

        private void setupDictionary()
        {
            DateTime current = Start;
            while (current.CompareTo(End) < 0)
            {
                HoursWorked.Add(current,0);
                current = current.AddDays(1);
            }
        }

        private void ProcessReports()
        {
            IList<Report> Reports = _reportRepository.FindByDurationAndEmployee(Start, End, _employee);
            foreach (var report in Reports)
            {
                foreach (var reportLine in report.Lines)
                {
                    if (reportLine.Item.GetType() == typeof (WorkHour))
                    {
                        if (HoursWorked.ContainsKey(report.Date))
                        {
                            HoursWorked[report.Date] += reportLine.Quantity;
                        }
                    }
                }
            }
        }
    }
}
