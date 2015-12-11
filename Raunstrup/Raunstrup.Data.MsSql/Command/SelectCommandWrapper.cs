using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Raunstrup.Data.MsSql.Criterion;

namespace Raunstrup.Data.MsSql.Command
{
    public class SelectCommandWrapper
    {
        private class Selection
        {
            public Selection(string name)
            {
                Name = name;
            }

            public string Name { get; set; }
            public string Alias { get; set; }
            public string Prefix { get; set; }

            public string Full
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

        private string _target;
        private readonly IList<Selection> _fields = new List<Selection>(); 
        
        public SelectCommandWrapper(IDbCommand command)
        {
            Command = command;
        }

        public IDbCommand Command { get; private set; }

        public SelectCommandWrapper Target(string target)
        {
            _target = target;

            return this;
        }

        public SelectCommandWrapper Field(string name)
        {
            return Field(name, string.Empty, string.Empty);
        }

        public SelectCommandWrapper Field(string name, string alias)
        {
            return Field(name, alias, string.Empty);
        }

        public SelectCommandWrapper Field(string name, string alias, string prefix)
        {
            _fields.Add(new Selection(name) { Alias = alias, Prefix = prefix });

            return this;
        }

        public SelectCommandWrapper Reset()
        {
            _fields.Clear();

            return this;
        }

        public SelectCommandWrapper Apply()
        {
            var sb = new StringBuilder("SELECT ")
                .AppendLine(string.Join(", ", _fields.Select(f => f.Full)))
                .Append("FROM ")
                .AppendLine(_target);

            Command.CommandText = sb.ToString();

            return this;
        }
    }
}
