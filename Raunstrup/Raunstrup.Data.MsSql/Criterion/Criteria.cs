using System.Collections.Generic;
using System.Linq;
using Raunstrup.Data.MsSql.Criterion;

namespace Raunstrup.Data.MsSql
{
    class Criteria
    {
        public readonly Expression Expression;

        private readonly IList<ICriterion> _criteria = new List<ICriterion>();

        public Criteria(Expression expression)
        {
            Expression = expression;
        }

        public Criteria Add(ICriterion criterion)
        {
            _criteria.Add(criterion);

            return this;
        }

        public string GetSql()
        {
            return string.Join(" AND ", _criteria.Select(x => x.GetSql()));
        }

        public override string ToString()
        {
            return GetSql();
        }
    }
}
