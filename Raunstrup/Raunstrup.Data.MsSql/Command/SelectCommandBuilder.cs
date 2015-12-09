using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Raunstrup.Data.MsSql.Command
{
    class SelectCommandBuilder
    {
        private readonly string _table;
        private readonly IList<string> _fields = new List<string>();
        private readonly IDictionary<string, string> _joins = new Dictionary<string, string>();
        private Criteria _criteria;

        public SelectCommandBuilder(string table)
        {
            _table = table;
        }

        public SelectCommandBuilder Join(string table, string criterion)
        {
            _joins.Add(table, criterion);

            return this;
        }

        public SelectCommandBuilder Where(Criteria criteria)
        {
            _criteria = criteria;

            return this;
        }

        public SqlCommand Build()
        {
            var command = new SqlCommand();
            var sb = new StringBuilder("SELECT " + string.Join(", ", _fields));

            sb.AppendLine("FROM " + _table);

            foreach (var @join in _joins)
            {
                sb.AppendLine(string.Format("JOIN {0} ON {1}", @join.Key, @join.Value));
            }

            command.CommandText = sb.ToString();

            return command;
        }
    }
}
