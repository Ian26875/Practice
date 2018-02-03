using MoneyTemplateMVC.Enum;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoneyTemplateMVC.Models.ViewModels
{
    public class MoneyCreateViewModel
    {
        [Display(Name = "類別")]
        public CategoryType Category { get; set; }

        [Required]
        [Remote("IsTodayBefore", "Home")]
        [Display(Name = "日期")]
        public DateTime CreateTime { get; set; }

        [Required]
        [Range(0,int.MaxValue)]
        [Display(Name = "金額")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "備註")]
        public string Remark { get; set; }

    }
}