using MoneyTemplateMVC.Enum;
using MoneyTemplateMVC.Models;
using MoneyTemplateMVC.Models.ViewModels;
using MoneyTemplateMVC.Repositories.Interface;
using MoneyTemplateMVC.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MoneyTemplateMVC.Helper;

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
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel));
            }
            var item = new AccountBook
            {
                Amounttt = Convert.ToInt32(viewModel.Amount),
                Categoryyy = (int)viewModel.Category,
                Dateee = viewModel.CreateTime,
                Remarkkk = viewModel.Remark

            };
            this._accountBookRepository.Insert(item);


        }

        public MoneyEditViewModel Get(Guid id)
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
                Category = x.Categoryyy.ParseEnum<CategoryType>(),
                CreateTime = x.Dateee
            })
            .OrderBy(x => x.CreateTime)
            .ToList();
            return viewModels;
        }

        public void UpdateMoneyBilling(MoneyEditViewModel editViewModel)
        {
            throw new NotImplementedException();
        }
    }
}