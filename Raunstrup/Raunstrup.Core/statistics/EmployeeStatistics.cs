using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raunstrup.Data.Repositories;
using Raunstrup.Domain;

namespace Raunstrup.Core.Statistics
{
    public class EmployeeStatistics
    {
        //This class uses a dictioanry to keep track of how many hours an employeee
        //have worked each day, between a start and end date
        //it scans reports to find out how many hours have been worked
        private readonly IDictionary<DateTime, int> HoursWorked = new Dictionary<DateTime, int>();
        public readonly DateTime Start;
        public readonly DateTime End;
        private readonly IReportRepository _reportRepository;
        private readonly Employee _employee;
        public EmployeeStatistics(IReportRepository reportRepository, Employee employee, DateTime start, DateTime end)
        {
            Start = start.Date;
            End = end.Date;
            _reportRepository = reportRepository;
            _employee = employee;
            if (Start.CompareTo(End) > 0)
            {
                throw new Exception("Start date must be earlier than end date");
            }
            SetupDictionary();
            ProcessReports();
        }

        public int GetLengthInDays()
        {
            var span = End.Subtract(Start);
            return span.Days;
        }

        public IDictionary<DateTime, int> GetHoursWorkedByDay()
        {
            return HoursWorked;
        }

        //Setups the dictionary, adding all dates between start and end
        private void SetupDictionary()
        {
            DateTime current = Start;
            while (current.CompareTo(End) < 0)
            {
                HoursWorked.Add(current,0);
                current = current.AddDays(1);
            }
        }

        //This gives a percent value according to how many hours have been invoiced
        //compared to how many working hours there is in the period, it assumes each day is
        //7 working hours, and does only checks for weekends, not holidays(as this would require
        //a lot more work)
        public double GetHoursInvoicedDegree()
        {
            double workingdays = 0;
            double hoursinvoiced = 0;
            foreach (var valuepair in HoursWorked)
            {
                if (valuepair.Key.DayOfWeek != DayOfWeek.Saturday && valuepair.Key.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingdays ++;
                    hoursinvoiced += valuepair.Value;
                }
            }
            return (hoursinvoiced / (workingdays * 7)*100);
        }

        //This processes the reports, finding all reportlines with workhours in it
        //and add it to the coresponding dates in the dictionary
        private void ProcessReports()
        {
            IList<Report> Reports = _reportRepository.FindByDurationAndEmployee(Start, End, _employee);
            foreach (var report in Reports)
            {
                foreach (var reportLine in report.ReportLines)
                {
                    if (reportLine.Product.GetType() == typeof (WorkHour))
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
