namespace Raunstrup.Data.MsSql.Command
{
    /// <summary>
    /// Represents a field.
    /// </summary>
    /// <remarks>No qouting is performed automatically.</remarks>
    class FieldInfo : ParameterInfo
    {
        /// <summary>
        /// The name of the field.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Creates a new <see cref="FieldInfo"/> instance.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public FieldInfo(string name)
        {
            Name = name;
        }
        
        /// <summary>
        /// The field's alias.
        /// </summary>
        public string Alias { get; set; }

        /// <summary>
        /// The field's prefix.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// The fully qualified field name.
        /// </summary>
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
