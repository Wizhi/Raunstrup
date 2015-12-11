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
        
        public string Alias { get; set; }

        public string Prefix { get; set; }

        public string FullName
        {
            get
            {
                var full = Name;

                if (Prefix != string.Empty)
                {
                    full = Prefix + "." + full;
                }

                if (Alias != string.Empty)
                {
                    full += " AS " + Alias;
                }

                return full;
            }
        }

        public DbType DbType { get; set; }
        public int Size { get; set; }
        public byte Precision { get; set; }
        public byte Scale { get; set; }
    }
}
