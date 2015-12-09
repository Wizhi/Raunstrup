using System;
using System.Collections.Generic;

namespace Raunstrup.Data.MsSql
{
    class Formatter
    {
        private readonly IDictionary<Type, Func<object, string>> _handlers = new Dictionary<Type, Func<object, string>>();

        public Formatter()
        {
            _handlers.Add(typeof(string), x => "'" + x + "'");
            _handlers.Add(typeof(int), x => x.ToString());
            _handlers.Add(typeof(DateTime), x => Value((DateTime) x));
        }

        public string Quote(string str)
        {
            return "[" + string.Join("].[", str.Split('.')) + "]";
        }

        public string Value(object value)
        {
            // TODO: Error handling for when no handler exists for the given type.
            return _handlers[value.GetType()](value);
        }

        public string Parameter(string name)
        {
            return "@" + name;
        }
    }
}
