namespace Raunstrup.Data.MsSql.Criterion
{
    class EqualsCriterion : ICriterion
    {
        private readonly string _field;
        private readonly object _value;

        public EqualsCriterion(string field, object value)
        {
            _field = field;
            _value = value;
        }

        public string GetSql()
        {
            return string.Format("{0}={1}", _field, _value);
        }

        public override string ToString()
        {
            return GetSql();
        }
    }
}
