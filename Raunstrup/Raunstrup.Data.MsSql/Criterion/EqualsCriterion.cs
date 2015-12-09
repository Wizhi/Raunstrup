namespace Raunstrup.Data.MsSql.Criterion
{
    class EqualsCriterion : ICriterion
    {
        private readonly Formatter _formatter;
        private readonly string _field;
        private readonly object _value;

        public EqualsCriterion(Formatter formatter, string field, object value)
        {
            _formatter = formatter;
            _field = field;
            _value = value;
        }

        public string GetSql()
        {
            return string.Format("{0}={1}", _formatter.Quote(_field), _formatter.Value(_value));
        }

        public override string ToString()
        {
            return GetSql();
        }
    }
}
