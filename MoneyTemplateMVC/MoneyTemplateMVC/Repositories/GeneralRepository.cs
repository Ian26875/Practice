using MoneyTemplateMVC.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using DapperExtensions;

namespace MoneyTemplateMVC.Repositories
{
    public class GeneralRepository<T> :RepositoryBase, IGeneralRepository<T> where T : class, new()
    {
        public GeneralRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public void Delete(T entity)
        {
            DbConnection.Delete(entity);
        }

        public T Find(object keyValues)
        {
            var source=DbConnection.Get<T>(keyValues);
            return source;
        }

        public IList<T> GetAll()
        {
            var source=DbConnection.GetList<T>();
            return source.ToList();
        }

        public void Insert(T entity)
        {
            DbConnection.Insert(entity);
        }

        public void Update(T entity)
        {
            DbConnection.Update(entity);
        }
    }
}