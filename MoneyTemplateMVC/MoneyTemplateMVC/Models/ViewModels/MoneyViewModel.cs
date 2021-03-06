﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MoneyTemplateMVC.Enum;

namespace MoneyTemplateMVC.Models.ViewModels
{
    public class MoneyViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "類別")]
        public CategoryType Category { get; set; }


        [Display(Name = "日期")]
        public DateTime CreateTime { get; set; }


        [Display(Name = "金額")]
        public decimal Amount { get; set; }
    }
}