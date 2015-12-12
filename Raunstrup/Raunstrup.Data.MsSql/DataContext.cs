using System.Data;
using System.Data.Common;

namespace Raunstrup.Data.MsSql
{
    /// <summary>
    /// The context used for interacting with the database.
    /// </summary>
    /// <remarks>Really it's just a wrapper around the <see cref="DbProviderFactory"/>..</remarks>
    public class DataContext
    {
        private readonly DbProviderFactory _providerFactory;
        private readonly string _connectionString;

        /// <summary>
        /// Creates a <see cref="DataContext"/>.
        /// </summary>
        /// <param name="providerFactory">The ADO.NET <see cref="DbProviderFactory"/> for the database type.</param>
        /// <param name="connectionString">The connection string for the database.</param>
        public DataContext(DbProviderFactory providerFactory, string connectionString)
        {
            _providerFactory = providerFactory;
            _connectionString = connectionString;
        }

        /// <summary>
        /// Creates a new <see cref="IDbConnection"/> using the provider.
        /// </summary>
        /// <returns></returns>
        public IDbConnection CreateConnection()
        {
            var connection = _providerFactory.CreateConnection();

            connection.ConnectionString = _connectionString;

            return connection;
        }
    }
}
