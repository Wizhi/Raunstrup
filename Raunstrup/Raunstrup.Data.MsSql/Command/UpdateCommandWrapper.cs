using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Raunstrup.Data.MsSql.Command
{
    class UpdateCommandWrapper : IDisposable
    {
        private string _target;
        private readonly ParameterBag _parameters;
        private readonly IDictionary<FieldInfo, IDbDataParameter> _sets = new Dictionary<FieldInfo, IDbDataParameter>(); 

        public UpdateCommandWrapper(IDbCommand command)
        {
            Command = command;
            _parameters = new ParameterBag(Command.CreateParameter);
        }

        public IDbCommand Command { get; private set; }

        public UpdateCommandWrapper Target(string target)
        {
            _target = target;

            return this;
        }
        
        public UpdateCommandWrapper Set(FieldInfo field, object value)
        {
            var param = _parameters.Add(field, value);

            _sets.Add(field, param);

            return this;
        }

        public UpdateCommandWrapper Reset()
        {
            foreach (var parameter in _parameters)
            {
                Command.Parameters.Remove(parameter);
            }

            _parameters.Clear();
            _sets.Clear();

            return this;
        }

        public UpdateCommandWrapper Apply()
        {
            var sb = new StringBuilder("UPDATE ")
                .AppendLine(_target)
                .AppendLine("SET");

            foreach (var pair in _sets)
            {
                // string.Format does add overhead, but whatever.
                sb.AppendLine(string.Format("{0}={1},", pair.Key.Name, pair.Value.ParameterName));
            }

            Command.CommandText = sb.ToString().TrimEnd().TrimEnd(',');

            return this;
        }

        public void Dispose()
        {
            Reset();
        }
    }
}
