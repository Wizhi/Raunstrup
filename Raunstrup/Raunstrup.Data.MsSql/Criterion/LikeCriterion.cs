namespace Raunstrup.Data.MsSql.Criterion
{
    class LikeCriterion : ICriterion
    {
        private readonly string _field;
        private readonly string _expression;

        public LikeCriterion(string field, string expression)
        {
            _field = field;
            _expression = expression;
        }

        public string GetSql()
        {
            return string.Format("{0} LIKE {1}", _field, _expression);
        }

        public override string ToString()
        {
            return GetSql();
        }
    }
}
