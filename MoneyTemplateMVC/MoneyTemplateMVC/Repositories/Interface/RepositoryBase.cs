using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Repositories.Interface
{
    /// <summary>
    /// RepositoryBase
    /// </summary>
    public abstract class RepositoryBase
    {

        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        protected IDbConnection Connection { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public RepositoryBase(IDbConnection connection)
        {
            this.Connection = connection;
        }
    }
}