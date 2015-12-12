using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace Raunstrup.Data.MsSql.Command
{
    /// <summary>
    /// A collection of parameters, which allows for auto-generating parameters.
    /// </summary>
    class ParameterBag : IEnumerable<IDbDataParameter>
    {
        private readonly Func<IDbDataParameter> _factory;
        private readonly IList<IDbDataParameter> _parameters = new List<IDbDataParameter>();

        /// <summary>
        /// Creates a <see cref="ParameterBag"/>.
        /// </summary>
        /// <remarks>If the <see cref="factory"/> returns a pre-existing IDbDataParameter instance, bugs are likely to occur.</remarks>
        /// <param name="factory">A method used for creating new IDbDataParameter instances.</param>
        public ParameterBag(Func<IDbDataParameter> factory)
        {
            _factory = factory;
        }
        
        /// <summary>
        /// Creates and adds a new <see cref="IDbDataParameter"/>.
        /// </summary>
        /// <param name="info">The <see cref="ParameterInfo"/> to base the <see cref="IDbDataParameter"/> on.</param>
        /// <param name="value">The value of the new <see cref="IDbDataParameter"/>.</param>
        /// <returns>The newly created <see cref="IDbDataParameter"/>.</returns>
        public IDbDataParameter Add(ParameterInfo info, object value)
        {
            var parameter = info.ToParameter(_factory);

            parameter.ParameterName = "@_p" + _parameters.Count;
            parameter.Value = value;

            _parameters.Add(parameter);

            return parameter;
        }

        /// <summary>
        /// Adds a <see cref="IDbDataParameter"/> to the collection.
        /// </summary>
        /// <remarks>Nothing but adding the <see cref="IDbDataParameter"/> is done, any attributes must be set manually.</remarks>
        /// <param name="parameter">The <see cref="IDbDataParameter"/> to be added.</param>
        public void Add(IDbDataParameter parameter)
        {
            _parameters.Add(parameter);
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        /// <remarks>Remember to remove <see cref="IDbDataParameter"/>'s from any <see cref="IDbCommand"/> they may be associated with.</remarks>
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
