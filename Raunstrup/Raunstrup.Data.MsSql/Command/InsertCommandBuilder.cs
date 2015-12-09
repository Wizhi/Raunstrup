using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Raunstrup.Data.MsSql.Command
{
    class InsertCommandBuilder
    {
        public IDictionary<string, IDbDataParameter> Parameters { get; set; } 

        private readonly string _table;
        private readonly Formatter _formatter;
        private readonly IList<string> _fields = new List<string>();
        private readonly IList<DbType> _types = new List<DbType>(); 
        private readonly IList<IList<object>> _values = new List<IList<object>>();

        public InsertCommandBuilder(string table)
        {
            _table = table;
            _formatter = new Formatter();
        }

        public InsertCommandBuilder Field(string name, DbType type)
        {
            _fields.Add(name);
            _types.Add(type);

            return this;
        }

        public InsertCommandBuilder Values(params object[] values)
        {
            _values.Add(values);

            return this;
        }

        public IDbCommand Build(Func<IDbCommand> commandProvider)
        {
            var command = commandProvider();
            var sb = new StringBuilder();

            sb
                .AppendLine("INSERT INTO " + _formatter.Quote(_table))
                .AppendLine("(" + string.Join(", ", _fields.Select(_formatter.Quote) + ")"))
                .AppendLine("VALUES");

            for (var i = 0; i < _values.Count; i++)
            {
                var names = new List<string>();

                foreach (var value in _values[i])
                {
                    IDbDataParameter parameter;

                    if (value is IDbDataParameter)
                    {
                        parameter = value as IDbDataParameter;

                        if (!Parameters.ContainsKey(parameter.ParameterName))
                        {
                            // TODO: Handle parameter not being user defined.
                        }
                    }
                    else
                    {
                        parameter = command.CreateParameter();

                        parameter.ParameterName = _formatter.Parameter("_" + _fields[i] + "_" + i);
                        parameter.Value = value;
                        parameter.DbType = _types[i];

                        command.Parameters.Add(parameter);
                    }

                    names.Add(parameter.ParameterName);
                }

                sb.AppendLine("(" + string.Join(", ", names) + ")");
            }

            command.CommandText = sb.ToString();

            return command;
        }
    }
}
