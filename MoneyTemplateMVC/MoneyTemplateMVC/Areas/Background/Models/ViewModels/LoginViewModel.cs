using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Areas.Background.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "帳號")]
        [StringLength(16)]
        public string Account { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "密碼")]
        [StringLength(16)]
        public string Password { get; set; }
    }
}