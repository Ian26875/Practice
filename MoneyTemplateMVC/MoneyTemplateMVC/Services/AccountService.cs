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


        /// <summary>
        /// The account book repository
        /// </summary>
        private IGeneralRepository<AccountBook> _accountBookRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountService"/> class.
        /// </summary>
        /// <param name="accountBookRepository">The account book repository.</param>
        public AccountService(IGeneralRepository<AccountBook> accountBookRepository)
        {
            this._accountBookRepository = accountBookRepository;
        }

        /// <summary>
        /// Creates the money billing.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void CreateMoneyBilling(MoneyCreateViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
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