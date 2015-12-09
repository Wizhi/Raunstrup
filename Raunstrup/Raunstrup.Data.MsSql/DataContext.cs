using System;
using System.Data;
using System.Data.Common;

namespace Raunstrup.Data.MsSql
{
    public class DataContext
    {
        private readonly DbProviderFactory _providerFactory;
        private readonly string _connectionString;

        public DataContext(DbProviderFactory providerFactory, string connectionString)
        {
            _providerFactory = providerFactory;
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var connection = _providerFactory.CreateConnection();

            connection.ConnectionString = _connectionString;

            return connection;
        }
    }
}
