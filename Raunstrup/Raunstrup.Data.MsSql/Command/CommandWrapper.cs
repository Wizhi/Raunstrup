using System;
using System.Data;

namespace Raunstrup.Data.MsSql.Command
{
    abstract class CommandWrapper : IDisposable
    {
        public readonly IDbCommand Command;

        /// <summary>
        /// The wrapped <see cref="IDbCommand"/>.
        /// </summary>
        public CommandWrapper(IDbCommand command)
        {
            Command = command;
        }

        /// <summary>
        /// Applies all information to the <see cref="IDbCommand"/> being wrapped.
        /// </summary>
        /// <remarks>No idiot checking is done, so an invalid <see cref="IDbCommand.CommandText"/> may be generated. Manual checking may be required.</remarks>
        /// <seealso cref="Reset"/>
        /// <returns></returns>
        public abstract CommandWrapper Apply();

        /// <summary>
        /// Removes all applied effects of the wrapper from the <see cref="IDbCommand"/> being wrapped.
        /// </summary>
        /// <remarks><see cref="IDbCommand.CommandText"/> is cleared as well.</remarks>
        /// <seealso cref="Command"/>
        /// <returns></returns>
        public abstract CommandWrapper Reset();
        
        public virtual void Dispose()
        {
            Reset();
        }
    }
}
