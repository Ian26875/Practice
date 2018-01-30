﻿using MoneyTemplateMVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTemplateMVC.Services.Interface
{
    public interface IAccountService
    {
        IList<MoneyViewModel> GetAll();
        void CreateMoneyBilling(MoneyCreateViewModel viewModel);
    }
}
