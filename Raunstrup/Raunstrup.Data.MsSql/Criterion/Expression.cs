namespace Raunstrup.Data.MsSql.Criterion
{
    class Expression
    {
        private readonly Formatter _formatter;

        public Expression(Formatter formatter)
        {
            _formatter = formatter;
        }

        public EqualsCriterion Equals(string field, object value)
        {
            return new EqualsCriterion(_formatter, field, value);
        }

        public LikeCriterion Like(string field, string expression)
        {
            return new LikeCriterion(_formatter, field, expression);
        }
    }
}
