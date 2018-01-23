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
        /// Gets or sets the database connection.
        /// </summary>
        /// <value>
        /// The database connection.
        /// </value>
        protected IDbConnection DbConnection { get; set; }

        /// <summary>
        /// Gets or sets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        protected IUnitOfWork _unitOfWork { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryBase"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this.DbConnection = _unitOfWork.Connection;
        }
    }
}