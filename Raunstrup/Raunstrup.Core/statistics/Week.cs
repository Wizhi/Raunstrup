using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raunstrup.Core.statistics
{
    public class Week : IEquatable<Week>,IComparable<Week>
    {
        public readonly DateTime StartDayDate;

        public Week(DateTime day)
        {
            DateTime tempStartDay = day;
            while (tempStartDay.DayOfWeek != DayOfWeek.Monday)
            {
                tempStartDay = tempStartDay.AddDays(-1);
            }
            StartDayDate = tempStartDay.Date;
        }
        public bool Equals(Week other)
        {
            return StartDayDate.Equals(other.StartDayDate);
        }

        public int CompareTo(Week other)
        {
            return StartDayDate.CompareTo(other.StartDayDate);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof (Week))
            {
                Week other = (Week) obj;
                return (Equals(other));
            }
            return false;
        }

        public override int GetHashCode()
        {
            return StartDayDate.DayOfYear + StartDayDate.Year*2;
        }
    }
}
