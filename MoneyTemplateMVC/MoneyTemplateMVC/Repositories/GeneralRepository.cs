using MoneyTemplateMVC.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class, new()
    {
        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public T Find(object keyValues)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}