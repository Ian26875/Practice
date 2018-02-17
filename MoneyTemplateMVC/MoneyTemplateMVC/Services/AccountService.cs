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
using DapperExtensions;

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

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public MoneyEditViewModel Get(Guid id)
        {
            var source = this._accountBookRepository
                .GetAll()
                .Single(x => x.Id == id);
            var entity = new MoneyEditViewModel
            {
                Amount = source.Amounttt,
                Category = source.Categoryyy.ParseEnum<CategoryType>(),
                DateTime = source.Dateee,
                Id = source.Id,
                Remark = source.Remarkkk

            };
            return entity;
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
                Id = x.Id,
                Amount = x.Amounttt,
                Category = x.Categoryyy.ParseEnum<CategoryType>(),
                CreateTime = x.Dateee
            })
            .OrderBy(x => x.CreateTime)
            .ToList();
            return viewModels;
        }

        public IList<MoneyViewModel> GetPages(int? year, int? month)
        {
            IBetweenPredicate predicates = null;

            if (year.HasValue && month.HasValue)
            {
                //每月一號
                DateTime monthStart = new DateTime(year.Value, month.Value, 1);
                //每月最後一天
                DateTime monthEnd = monthStart.AddMonths(1).AddDays(-1);
                BetweenValues betweenValues = new BetweenValues
                {
                    Value1 = monthStart,
                    Value2 = monthEnd,
                };
                predicates = Predicates.Between<AccountBook>(f => 
                f.Dateee, betweenValues);
            }
            var sort = new List<ISort>
            {
                Predicates.Sort<AccountBook>(x=>x.Dateee),
                Predicates.Sort<AccountBook>(x=>x.Categoryyy)
            };
            var source = this._accountBookRepository.GetList(predicates, sort);
            var viewModels = source.Select(x =>
            new MoneyViewModel
            {
                Id = x.Id,
                Amount = x.Amounttt,
                Category = x.Categoryyy.ParseEnum<CategoryType>(),
                CreateTime = x.Dateee
            }).ToList();

            return viewModels;
        }

        /// <summary>
        /// Updates the money billing.
        /// </summary>
        /// <param name="editViewModel">The edit view model.</param>
        public void UpdateMoneyBilling(MoneyEditViewModel editViewModel)
        {
            var entity = new AccountBook
            {
                Id = editViewModel.Id,
                Dateee = editViewModel.DateTime,
                Amounttt = Convert.ToInt32(editViewModel.Amount),
                Categoryyy = (int)editViewModel.Category,
                Remarkkk = editViewModel.Remark
            };
            this._accountBookRepository.Update(entity);
        }
    }
}