using System.Data;

namespace Raunstrup.Data.MsSql.Queries
{
    /// <summary>
    /// The base interface for all queries.
    /// </summary>
    /// <remarks>
    /// Due to the "incomplete" implementation of the repository pattern, buisness logic related queries have been moved to individual classes.
    /// It's kind of messy, but it's a lot cleaner.
    /// </remarks>
    /// <typeparam name="T">The type which <see cref="Execute"/> must return.</typeparam>
    interface IQuery<T>
    {
        /// <summary>
        /// Executes the query in the given context.
        /// </summary>
        /// <param name="context">The <see cref="DataContext"/> to execute the query in.</param>
        /// <returns></returns>
        //T Execute(DataContext context);
        /// <summary>
        /// Executes the query in the given context.
        /// </summary>
        /// <param name="context">The <see cref="DataContext"/> to execute the query in.</param>
        /// <returns></returns>
        IDataReader Execute(IDbConnection context);
    }
}
