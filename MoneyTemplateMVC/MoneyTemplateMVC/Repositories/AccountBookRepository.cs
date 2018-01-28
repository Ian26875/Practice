using MoneyTemplateMVC.Models;
using MoneyTemplateMVC.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Dapper;

namespace MoneyTemplateMVC.Repositories
{
    public class AccountBookRepository : RepositoryBase, IAccountBookRepository
    {
        public AccountBookRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public IList<AccountBook> GetAll()
        {
            const string sql = "SELECT * FROM AccountBook";
            var source = DbConnection.Query<AccountBook>(sql);
            return source.ToList();
        }
    }
}