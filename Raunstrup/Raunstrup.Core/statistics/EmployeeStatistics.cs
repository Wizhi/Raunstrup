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
            if (Start.CompareTo(End) < 0)
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

        public IDictionary<Week, int> GetHoursWorkedByWeek()
        {
            Dictionary<Week, int> returnDictionary = new Dictionary<Week, int>();
            Week tempWeek;
            foreach (var date in HoursWorked.Keys)
            {
                tempWeek = new Week(date);
                if (returnDictionary.ContainsKey(tempWeek))
                {
                    returnDictionary[tempWeek] += HoursWorked[date];
                }
                else
                {
                    returnDictionary.Add(tempWeek, HoursWorked[date]);
                }
            }
            return returnDictionary;
        } 

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
            int workingdays = 0;
            int hoursinvoiced = 0;
            foreach (var valuepair in HoursWorked)
            {
                if (valuepair.Key.DayOfWeek != DayOfWeek.Saturday && valuepair.Key.DayOfWeek != DayOfWeek.Sunday)
                {
                    workingdays ++;
                    hoursinvoiced += valuepair.Value;
                }
            }
            return hoursinvoiced/(workingdays*7);
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
