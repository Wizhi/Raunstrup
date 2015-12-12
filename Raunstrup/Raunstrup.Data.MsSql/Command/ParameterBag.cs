﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

namespace Raunstrup.Data.MsSql.Command
{
    class ParameterBag : IEnumerable<IDbDataParameter>
    {
        private readonly Func<IDbDataParameter> _factory;
        private readonly IList<IDbDataParameter> _parameters = new List<IDbDataParameter>();

        public ParameterBag(Func<IDbDataParameter> factory)
        {
            _factory = factory;
        }

        public IReadOnlyCollection<IDbDataParameter> Parameters
        {
            get { return new ReadOnlyCollection<IDbDataParameter>(_parameters); }
        }

        public IDbDataParameter Add(ParameterInfo info, object value)
        {
            var parameter = info.ToParameter(_factory);

            parameter.ParameterName = "@_p" + _parameters.Count;
            parameter.Value = value;

            _parameters.Add(parameter);

            return parameter;
        }

        public void Add(IDbDataParameter parameter)
        {
            _parameters.Add(parameter);
        }

        public void Clear()
        {
            _parameters.Clear();
        }

        public IEnumerator<IDbDataParameter> GetEnumerator()
        {
            return _parameters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
