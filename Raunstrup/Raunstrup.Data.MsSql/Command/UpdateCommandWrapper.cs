using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Raunstrup.Data.MsSql.Command
{
    class UpdateCommandWrapper : IDisposable
    {
        private string _target;
        private readonly ParameterBag _parameters;
        private readonly IDictionary<FieldInfo, IDbDataParameter> _sets = new Dictionary<FieldInfo, IDbDataParameter>();
        private string _constraint;

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

        public UpdateCommandWrapper Where(string constraint)
        {
            _constraint = constraint;

            return this;
        }

        public UpdateCommandWrapper Parameter(ParameterInfo info, string name, object value)
        {
            var parameter = info.ToParameter(Command.CreateParameter);

            parameter.ParameterName = name;
            parameter.Value = value;

            _parameters.Add(parameter);

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

            foreach (var parameter in _parameters)
            {
                Command.Parameters.Add(parameter);
            }

            sb.AppendLine(
                string.Join(", ",
                _sets.Select(pair => string.Format("{0}={1}", pair.Key.Name, pair.Value.ParameterName)))
            );

            if (_constraint != string.Empty)
            {
                sb.AppendLine(" WHERE " + _constraint);
            }

            Command.CommandText = sb.ToString();

            return this;
        }

        public void Dispose()
        {
            Reset();
        }
    }
}
