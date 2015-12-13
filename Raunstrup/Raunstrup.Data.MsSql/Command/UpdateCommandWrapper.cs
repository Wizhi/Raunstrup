using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Raunstrup.Data.MsSql.Command
{
    /// <summary>
    /// A wrapper for an <see cref="IDbCommand"/>, which provides a simple fluent interface for defining UPDATE statements.
    /// </summary>
    /// <remarks>This wrapper isn't idiot proof. Please use don't break things.</remarks>
    class UpdateCommandWrapper : CommandWrapper
    {
        /// <summary>
        /// The target for the statement.
        /// </summary>
        /// <remarks>This is usually a table.</remarks>
        /// <seealso cref="Target"/>
        private string _target;

        /// <summary>
        /// The <see cref="ParameterBag"/> which keeps track of <see cref="IDbCommand"/>s for the command.
        /// </summary>
        private readonly ParameterBag _parameters;

        /// <summary>
        /// The pairs of <see cref="FieldInfo"/> and values to be updated.
        /// </summary>
        /// <remarks>There's no support for literal values.</remarks>
        /// <seealso cref="FieldInfo"/>
        /// <see cref="Set"/>
        private readonly IDictionary<FieldInfo, IDbDataParameter> _sets = new Dictionary<FieldInfo, IDbDataParameter>();

        /// <summary>
        /// A super naive WHERE clause constraint.
        /// </summary>
        /// <remarks>The constraint is considered "finished" when applied, so a full constraint should be generated, and then set.</remarks>
        /// <seealso cref="Where"/>
        private string _constraint;

        /// <summary>
        /// Creates a <see cref="UpdateCommandWrapper"/> for the given <see cref="IDbCommand"/>.
        /// </summary>
        /// <param name="command">The <see cref="IDbCommand"/> to wrap.</param>
        public UpdateCommandWrapper(IDbCommand command) 
            : base(command)
        {
            _parameters = new ParameterBag(Command.CreateParameter);
        }
        
        /// <summary>
        /// Sets the target for the statement.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public UpdateCommandWrapper Target(string target)
        {
            _target = target;

            return this;
        }
        
        /// <summary>
        /// Adds a field to be updated.
        /// </summary>
        /// <param name="field">The <see cref="FieldInfo"/> to base the field on.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public UpdateCommandWrapper Set(FieldInfo field, object value)
        {
            var param = _parameters.Add(field, value);

            _sets.Add(field, param);

            return this;
        }

        /// <summary>
        /// Adds a single constraint against the UPDATE.
        /// </summary>
        /// <remarks>Implementation laziness is attributed to KISS.</remarks>
        /// <see cref="_constraint"/>
        /// <param name="constraint">The SQL constraint.</param>
        /// <returns></returns>
        public UpdateCommandWrapper Where(string constraint)
        {
            _constraint = constraint;

            return this;
        }

        /// <summary>
        /// Adds a parameter to the <see cref="IDbCommand"/>.
        /// </summary>
        /// <param name="info">The <see cref="ParameterInfo"/> to base the parameter on.</param>
        /// <param name="name">The name of the <see cref="IDbDataParameter"/>.</param>
        /// <param name="value">The value of the <see cref="IDbDataParameter"/>.</param>
        /// <returns></returns>
        public UpdateCommandWrapper Parameter(ParameterInfo info, string name, object value)
        {
            var parameter = info.ToParameter(Command.CreateParameter);

            parameter.ParameterName = name;
            parameter.Value = value;

            _parameters.Add(parameter);

            return this;
        }

        /// <summary>
        /// Applies all information to the <see cref="IDbCommand"/> being wrapped.
        /// </summary>
        /// <remarks>No idiot checking is done, so an invalid <see cref="IDbCommand.CommandText"/> may be generated. Manual checking may be required.</remarks>
        /// <seealso cref="Reset"/>
        /// <returns></returns>
        public override CommandWrapper Apply()
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

        /// <summary>
        /// Removes all applied effects of the wrapper from the <see cref="IDbCommand"/> being wrapped.
        /// </summary>
        /// <remarks><see cref="IDbCommand.CommandText"/> is cleared as well.</remarks>
        /// <seealso cref="Command"/>
        /// <returns></returns>
        public override CommandWrapper Reset()
        {
            // We only want to remove the generated parameters.
            foreach (var parameter in _parameters.Where(parameter => Command.Parameters.Contains(parameter)))
            {
                Command.Parameters.Remove(parameter);
            }

            _parameters.Clear();
            _sets.Clear();

            return this;
        }
    }
}
