using MoneyTemplateMVC.Models.ViewModels;
using MoneyTemplateMVC.Repositories.Interface;
using MoneyTemplateMVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Services
{
    public class AccountService : IAccountService
    {


        private IAccountBookRepository _accountBookRepository;
        public AccountService(IAccountBookRepository accountBookRepository)
        {
            this._accountBookRepository = accountBookRepository;
        }


        public IList<MoneyViewModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}