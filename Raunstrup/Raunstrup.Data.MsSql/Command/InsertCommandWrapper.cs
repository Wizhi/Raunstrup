using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Raunstrup.Data.MsSql.Command
{
    public class InsertCommandWrapper
    {
        private string _target;
        private readonly IList<FieldInfo> _fields = new List<FieldInfo>();
        private readonly IList<IDbDataParameter> _parameters = new List<IDbDataParameter>();
        private readonly IList<IList<string>> _names = new List<IList<string>>(); 
        
        public InsertCommandWrapper(IDbCommand command)
        {
            Command = command;
        }

        public IDbCommand Command { get; private set; }

        public InsertCommandWrapper Target(string target)
        {
            _target = target;

            return this;
        }

        public InsertCommandWrapper Field(FieldInfo info)
        {
            _fields.Add(info);

            return this;
        }

        public InsertCommandWrapper Field(string name, DbType type, byte precision, byte scale)
        {
            _fields.Add(new FieldInfo(name)
            {
                DbType = type,
                Precision = precision,
                Scale = scale
            });

            return this;
        }

        public InsertCommandWrapper Field(string name, DbType type, int size)
        {
            _fields.Add(new FieldInfo(name)
            {
                DbType = type,
                Size = size 
            });

            return this;
        }

        public InsertCommandWrapper Values(params object[] values)
        {
            if (values.Length != _fields.Count)
            {
                // TODO: Handle number of values doesn't match number of fields.
            }

            // TODO: Consider storing the values instead, and then building parameters when applied.
            var names = new string[values.Length];

            for (var i = 0; i < values.Length; i++)
            {
                var value = values[i];
                IDbDataParameter parameter;

                if (value is IDbDataParameter)
                {
                    parameter = (IDbDataParameter) value;
                }
                else
                {
                    var field = _fields[i];
                    parameter = Command.CreateParameter();

                    parameter.ParameterName = "@_p" + _parameters.Count;
                    parameter.DbType = field.DbType;
                    parameter.Size = field.Size;
                    parameter.Precision = field.Precision;
                    parameter.Scale = field.Scale;
                    parameter.Value = value;
                }

                names[i] = parameter.ParameterName;
                _parameters.Add(parameter);
            }

            _names.Add(names);

            return this;
        }

        public InsertCommandWrapper Reset()
        {
            Command.CommandText = string.Empty;

            // We only want to remove the generated parameters.
            foreach (var parameter in _parameters)
            {
                Command.Parameters.Remove(parameter);
            }

            _parameters.Clear();
            _names.Clear();

            return this;
        }

        public InsertCommandWrapper Apply()
        {
            var sb = new StringBuilder("INSERT INTO ")
                .Append(_target)
                .AppendLine(" (" + string.Join(", ", _fields.Select(f => f.Name)) + ")")
                .AppendLine("VALUES");

            foreach (var parameter in _parameters)
            {
                Command.Parameters.Add(parameter);
            }

            foreach (var names in _names)
            {
                sb.AppendLine("(" + string.Join(", ", names) + "),");
            }

            // We need to trim whitespace, and then trailing comma.
            Command.CommandText = sb.ToString().TrimEnd().TrimEnd(',') + ";";

            return this;
        }
    }
}
