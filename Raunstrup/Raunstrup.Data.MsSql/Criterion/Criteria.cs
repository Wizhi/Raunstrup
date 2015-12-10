using System.Collections.Generic;
using System.Linq;

namespace Raunstrup.Data.MsSql.Criterion
{
    class Criteria
    {
        private readonly IList<ICriterion> _criteria = new List<ICriterion>();
        
        public Criteria Add(ICriterion criterion)
        {
            _criteria.Add(criterion);

            return this;
        }

        public string GetSql()
        {
            return "(" + string.Join(") AND (", _criteria.Select(x => x.GetSql())) + ")";
        }

        public override string ToString()
        {
            return GetSql();
        }
    }
}
