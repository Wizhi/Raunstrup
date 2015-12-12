using System;
using System.Data;

namespace Raunstrup.Data.MsSql.Command
{
    class FieldInfo : ParameterInfo
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
    }
}
