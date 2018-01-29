using MoneyTemplateMVC.Enum;
using MoneyTemplateMVC.Models;
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


        private IGeneralRepository<AccountBook> _accountBookRepository;
        public AccountService(IGeneralRepository<AccountBook> accountBookRepository)
        {
            this._accountBookRepository = accountBookRepository;
        }


        public IList<MoneyViewModel> GetAll()
        {
            var source = this._accountBookRepository.GetAll();
            var viewModels = source.Select(x =>
            new MoneyViewModel
            {
                Amount = x.Amounttt,
                Category = (CategoryType)System.Enum.Parse(typeof(CategoryType),x.Categoryyy.ToString()),
                CreateTime = x.Dateee
            }).ToList();
            return viewModels;
        }
    }
}