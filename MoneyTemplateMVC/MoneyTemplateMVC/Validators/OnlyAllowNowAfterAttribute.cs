using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Validators
{
    public class OnlyAllowNowAfterAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                var dateTime = Convert.ToDateTime(value);
                return DateTime.Now.Year <= dateTime.Year
                    && DateTime.Now.DayOfYear <= dateTime.DayOfYear;
            }
            return base.IsValid(value);
        }
    }
}