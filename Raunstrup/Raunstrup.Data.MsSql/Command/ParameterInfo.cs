using System;
using System.Data;

namespace Raunstrup.Data.MsSql.Command
{
    class ParameterInfo
    {
        public DbType DbType { get; set; }
        public int Size { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }

        public IDbDataParameter ToParameter(Func<IDbDataParameter> factory)
        {
            var parameter = factory();

            parameter.DbType = DbType;
            parameter.Size = Size;
            parameter.Precision = Precision;
            parameter.Scale = Scale;

            return parameter;
        }
    }
}
