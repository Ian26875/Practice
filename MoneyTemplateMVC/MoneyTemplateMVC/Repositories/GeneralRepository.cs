using MoneyTemplateMVC.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using DapperExtensions;

namespace MoneyTemplateMVC.Repositories
{
    public class GeneralRepository<T> : RepositoryBase, IGeneralRepository<T> where T : class, new()
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
            var source = DbConnection.Get<T>(keyValues);
            return source;
        }

        public IList<T> GetAll()
        {
            var source = DbConnection.GetList<T>();
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

        public IList<T> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage)
        {
            var source = DbConnection.GetPage<T>(predicate, sort, page, resultsPerPage).ToList();
            return source;
        }

        public IList<T> GetList(object predicate, IList<ISort> sort = null)
        {
            var source = DbConnection.GetList<T>(predicate, sort).ToList();
            return source;
        }
    }
}