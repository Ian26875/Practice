using MoneyTemplateMVC.Repositories.DB;
using MoneyTemplateMVC.Repositories.Interface;
using System.Data;

namespace MoneyTemplateMVC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IConnectionFactory _connectionFactory;

        public IDbTransaction Transaction { get; private set; }

        public IDbConnection Connection { get; private set; }

        public UnitOfWork(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;

            this.Connection = _connectionFactory.Create();
        }

        public void BeginTransaction()
        {
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
        }

        public void Rollback()
        {
            Transaction.Rollback();
        }
    }
}