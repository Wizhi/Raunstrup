using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Raunstrup.Data.MsSql.Command
{
    class UpdateCommandBuilder
    {
        private readonly string _table;
        private readonly Formatter _formatter;
        private readonly IDictionary<string, object> _pairs = new Dictionary<string, object>();
        private Criteria _criteria;

        public UpdateCommandBuilder(string table, Formatter formatter)
        {
            _table = table;
            _formatter = formatter;
        }

        public UpdateCommandBuilder Set(string field, object value)
        {
            _pairs.Add(field, value);

            return this;
        }

        public UpdateCommandBuilder Where(Criteria criteria)
        {
            _criteria = criteria;

            return this;
        }

        public SqlCommand Build()
        {
            var command = new SqlCommand();
            var sb = new StringBuilder("UPDATE TABLE " + _formatter.Quote(_table));

            foreach (var pair in _pairs)
            {
                sb.AppendLine("SET " + _formatter.Quote(pair.Key) + "=" + _formatter.Value(pair.Value));
            }

            if (_criteria != null)
            {
                sb.AppendLine(_criteria.GetSql());
            }

            command.CommandText = sb.ToString();

            return command;
        }
    }
}
