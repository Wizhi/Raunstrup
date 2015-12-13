using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Raunstrup.Data.MsSql.Command
{
    /// <summary>
    /// A wrapper for an <see cref="IDbCommand"/>, which provides a simple fluent interface for defining INSERT INTO statements.
    /// </summary>
    /// <remarks>This wrapper isn't idiot proof. Please use don't break things.</remarks>
    class InsertCommandWrapper : CommandWrapper
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
        /// The fields which are inserted into.
        /// </summary>
        /// <seealso cref="FieldInfo"/>
        /// <seealso cref="Field(Raunstrup.Data.MsSql.Command.FieldInfo)"/>
        private readonly IList<FieldInfo> _fields = new List<FieldInfo>();

        /// <summary>
        /// The parameter names in groups.
        /// </summary>
        /// <seealso cref="Apply"/>
        private readonly IList<IList<string>> _names = new List<IList<string>>();

        /// <summary>
        /// The static values added to each set of <see cref="Values"/>.
        /// </summary>
        /// <seealso cref="Static(Raunstrup.Data.MsSql.Command.FieldInfo,string)"/>
        /// <seealso cref="Static(Raunstrup.Data.MsSql.Command.FieldInfo,string,out IDbDataParameter)"/>
        /// <seealso cref="Static(Raunstrup.Data.MsSql.Command.FieldInfo,string,object)"/>
        private readonly IList<string> _statics = new List<string>();
        
        /// <summary>
        /// Creates a <see cref="InsertCommandWrapper"/> for the given <see cref="IDbCommand"/>.
        /// </summary>
        /// <param name="command">The <see cref="IDbCommand"/> to wrap.</param>
        public InsertCommandWrapper(IDbCommand command)
            : base(command)
        {
            _parameters = new ParameterBag(command.CreateParameter);
        }
        
        /// <summary>
        /// Sets the target for the statement.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public InsertCommandWrapper Target(string target)
        {
            _target = target;

            return this;
        }

        /// <summary>
        /// Adds a <see cref="FieldInfo"/> to the list of fields to insert into.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public InsertCommandWrapper Field(FieldInfo info)
        {
            _fields.Add(info);

            return this;
        }
        
        /// <summary>
        /// Append a set of values to insert.
        /// </summary>
        /// <remarks>Like a regular INSERT INTO statement, the order of the values must match the order of the fields.</remarks>
        /// <param name="values">A set of values to insert.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds a static value to all sets of values being inserted.
        /// </summary>
        /// <remarks>Nothing is done to the <see cref="value"/>. Any formatting or quoting must be done manually.</remarks>
        /// <param name="field">The <see cref="FieldInfo"/> to base the field on.</param>
        /// <param name="value">The value to insert. Must be formatted as a string.</param>
        /// <returns></returns>
        public InsertCommandWrapper Static(FieldInfo field, string value)
        {
            _fields.Add(field);
            _statics.Add(value);

            return this;
        }

        /// <summary>
        /// Adds a statick value to all sets of values being inserted as a new parameter, which is then binded to <see cref="parameter"/>.
        /// </summary>
        /// <remarks>The created <see cref="IDbDataParameter"/> has no set value. This is for the end user to set.</remarks>
        /// <param name="field">The <see cref="FieldInfo"/> to base the field on. Also used for creating the <see cref="IDbDataParameter"/>.</param>
        /// <param name="name">The name of the <see cref="IDbDataParameter"/>.</param>
        /// <param name="parameter">The <see cref="IDbDataParameter"/> to bind the created <see cref="IDbDataParameter"/> to.</param>
        /// <returns></returns>
        public InsertCommandWrapper Static(FieldInfo field, string name, out IDbDataParameter parameter)
        {
            parameter = field.ToParameter(Command.CreateParameter);
            parameter.ParameterName = name;
            
            _parameters.Add(parameter);

            return Static(field, name);
        }

        /// <summary>
        /// Adds a statick value to all sets of values being inserted as a new parameter.
        /// </summary>
        /// <param name="field">The <see cref="FieldInfo"/> to base the field on. Also used for creating the <see cref="IDbDataParameter"/>.</param>
        /// <param name="name">The <see cref="IDbDataParameter.ParameterName"/> of the paramenter.</param>
        /// <param name="value">The value of the created <see cref="IDbDataParameter"/>.</param>
        /// <returns></returns>
        public InsertCommandWrapper Static(FieldInfo field, string name, object value)
        {
            var parameter = field.ToParameter(Command.CreateParameter);

            parameter.ParameterName = name;
            parameter.Value = value;

            _parameters.Add(parameter);

            return Static(field, name);
        }

        /// <summary>
        /// Applies all information to the <see cref="IDbCommand"/> being wrapped.
        /// </summary>
        /// <remarks>No idiot checking is done, so an invalid <see cref="IDbCommand.CommandText"/> may be generated. Manual checking may be required.</remarks>
        /// <seealso cref="Reset"/>
        /// <returns></returns>
        public override CommandWrapper Apply()
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

        /// <summary>
        /// Removes all applied effects of the wrapper from the <see cref="IDbCommand"/> being wrapped.
        /// </summary>
        /// <remarks><see cref="IDbCommand.CommandText"/> is cleared as well.</remarks>
        /// <seealso cref="Command"/>
        /// <returns></returns>
        public override CommandWrapper Reset()
        {
            Command.CommandText = string.Empty;

            // We only want to remove the generated parameters.
            foreach (var parameter in _parameters.Where(parameter => Command.Parameters.Contains(parameter)))
            {
                Command.Parameters.Remove(parameter);
            }

            _parameters.Clear();
            _names.Clear();

            return this;
        }
    }
}
