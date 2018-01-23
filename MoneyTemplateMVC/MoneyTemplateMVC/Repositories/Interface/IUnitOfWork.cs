using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTemplateMVC.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IDbTransaction Transaction { get; }
        IDbConnection Connection { get; }
        IDbTransaction BeginTransaction();
        void Commit();
        void Rollback();
    }
}
