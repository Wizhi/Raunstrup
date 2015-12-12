using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Raunstrup.Data.MsSql.Command
{
    class InsertCommandWrapper : IDisposable
    {
        private string _target;
        private readonly ParameterBag _parameters;
        private readonly IList<FieldInfo> _fields = new List<FieldInfo>();
        private readonly IList<IList<string>> _names = new List<IList<string>>(); 
        private readonly IList<string> _statics = new List<string>();
        
        public InsertCommandWrapper(IDbCommand command)
        {
            Command = command;
            _parameters = new ParameterBag(command.CreateParameter);
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
            var names = new string[values.Length];

            for (var i = 0; i < values.Length; i++)
            {
                var parameter = _parameters.Add(_fields[i], values[i]);

                names[i] = parameter.ParameterName;
            }

            _names.Add(names);
            
            return this;
        }

        public InsertCommandWrapper Static(FieldInfo field, string value)
        {
            _fields.Add(field);
            _statics.Add(value);

            return this;
        }

        public InsertCommandWrapper Static(FieldInfo field, string name, out IDbDataParameter parameter)
        {
            parameter = field.ToParameter(Command.CreateParameter);
            parameter.ParameterName = name;
            
            _parameters.Add(parameter);

            return Static(field, name);
        }

        public InsertCommandWrapper Static(FieldInfo field, string name, object value)
        {
            _parameters.Add(field, value);

            return Static(field, name);
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
            
            sb.Append(
                string.Join(
                    ", ",
                    _names.Select(names => "(" + string.Join(", ", names.Concat(_statics)) + ")")
                )
            );
            
            Command.CommandText = sb.AppendLine(";").ToString();

            return this;
        }

        public void Dispose()
        {
            Reset();
        }
    }
}
