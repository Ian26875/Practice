using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTemplateMVC.Repositories.Interface
{
    public interface IGeneralRepository<T> where T : class, new()
    {
        IList<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Find(object keyValues);
        IList<T> GetPage(object predicate, IList<ISort> sort, int page, int resultsPerPage);
        IList<T> GetList(object predicate, IList<ISort> sort = null);
    }
}
