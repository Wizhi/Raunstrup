namespace Raunstrup.Data.MsSql.Criterion
{
    static class Expression
    {
        public static EqualsCriterion Equals(string field, object value)
        {
            return new EqualsCriterion(field, value);
        }

        public static LikeCriterion Like(string field, string expression)
        {
            return new LikeCriterion(field, expression);
        }
    }
}
