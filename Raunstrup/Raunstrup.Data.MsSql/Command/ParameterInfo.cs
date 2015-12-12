using System;
using System.Data;

namespace Raunstrup.Data.MsSql.Command
{
    /// <summary>
    /// Represents information of a <see cref="IDbDataParameter"/>.
    /// </summary>
    class ParameterInfo
    {
        /// <summary>
        /// Creates/populates an <see cref="IDbDataParameter"/> instance based on the information.
        /// </summary>
        /// <param name="factory">A method which returns a <see cref="IDbDataParameter"/> instance.</param>
        /// <returns>A full <see cref="IDbDataParameter"/> based on the information.</returns>
        public IDbDataParameter ToParameter(Func<IDbDataParameter> factory)
        {
            var parameter = factory();

            parameter.DbType = DbType;
            parameter.Size = Size;
            parameter.Precision = Precision;
            parameter.Scale = Scale;

            return parameter;
        }

        /// <summary>
        /// The <see cref="DbType"/> of the value.
        /// </summary>
        /// <seealso cref="IDbDataParameter"/>
        public DbType DbType { get; set; }

        /// <summary>
        /// The maximum size of the parameter.
        /// </summary>
        /// <seealso cref="IDbDataParameter.Size"/>
        public int Size { get; set; }

        /// <summary>
        /// Indicates the precision for numeric parameters.
        /// </summary>
        /// <seealso cref="IDbDataParameter.Precision"/>
        public byte Precision { get; set; }

        /// <summary>
        /// Indicates the scale for numeric parameters.
        /// </summary>
        /// <seealso cref="IDbDataParameter.Scale"/>
        public byte Scale { get; set; }
    }
}
