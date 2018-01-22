using MoneyTemplateMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTemplateMVC.Repositories.Interface
{
    public interface IAccountBookRepository
    {
        IEnumerable<AccountBook> GetAll();
    }
}
