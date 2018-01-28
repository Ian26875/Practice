using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Enum
{
    /// <summary>
    /// CategoryType
    /// </summary>
    public enum CategoryType
    {
        /// <summary>
        /// 支出
        /// </summary>
        [Display(Name = "支出")]
        Expend,
        /// <summary>
        /// 收入
        /// </summary>
        [Display(Name = "收入")]
        Income
    }
}