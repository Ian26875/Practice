using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Repositories.DB
{
    /// <summary>
    /// ConnectionFactory
    /// </summary>
    public class ConnectionFactory : IConnectionFactory
    {

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>
        /// The connection string.
        /// </value>
        public string ConnectionString { get; private set; }


        /// <summary>
        /// Gets the name of the provider.
        /// </summary>
        /// <value>
        /// The name of the provider.
        /// </value>
        public string ProviderName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionFactory"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="providerName">Name of the provider.</param>
        /// <exception cref="ArgumentNullException">
        /// connectionString
        /// or
        /// providerName
        /// </exception>
        public ConnectionFactory(string connectionString, string providerName)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString));
            }
            if (string.IsNullOrWhiteSpace(providerName))
            {
                throw new ArgumentNullException(nameof(providerName));
            }
            ConnectionString = connectionString;
            ProviderName = providerName;
        }


        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns></returns>
        public IDbConnection Create()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory(ProviderName);
            DbConnection dbConnection = factory.CreateConnection();
            dbConnection.ConnectionString = ConnectionString;
            return dbConnection;
        }

    }
}