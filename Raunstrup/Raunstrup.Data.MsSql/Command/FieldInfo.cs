using System.Data;

namespace Raunstrup.Data.MsSql.Command
{
    public class FieldInfo
    {
        public readonly string Name;

        public FieldInfo(string name)
        {
            Name = name;
        }

        public DbType DbType { get; set; }
        public int Size { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }
    }
}
