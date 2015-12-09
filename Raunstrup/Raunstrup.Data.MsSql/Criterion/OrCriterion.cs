namespace Raunstrup.Data.MsSql.Criterion
{
    class OrCriterion : ICriterion
    {
        private readonly ICriterion _left;
        private readonly ICriterion _right;

        public OrCriterion(ICriterion left, ICriterion right)
        {
            _left = left;
            _right = right;
        }

        public string GetSql()
        {
            return string.Format("{0} OR {1}", _left.GetSql(), _right.GetSql());
        }
    }
}
