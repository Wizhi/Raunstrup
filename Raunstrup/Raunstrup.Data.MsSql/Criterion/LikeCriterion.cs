namespace Raunstrup.Data.MsSql.Criterion
{
    class LikeCriterion : ICriterion
    {
        private readonly Formatter _formatter;
        private readonly string _field;
        private readonly string _expression;

        public LikeCriterion(Formatter formatter, string field, string expression)
        {
            _formatter = formatter;
            _field = field;
            _expression = expression;
        }

        public string GetSql()
        {
            return string.Format("{0} LIKE {1}", _formatter.Quote(_field), _formatter.Value(_expression));
        }

        public override string ToString()
        {
            return GetSql();
        }
    }
}
