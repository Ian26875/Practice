using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Validators
{
    public class OnlyAllowNowBeforeAttribute: ValidationAttribute
    {
        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">要驗證之物件的值。</param>
        /// <returns>
        /// <see langword="true" /> 指定的值是否有效。否則， <see langword="false" />。
        /// </returns>
        public override bool IsValid(object value)
        {
            if (value is DateTime)
            {
                var dateTime = Convert.ToDateTime(value);
                bool isValidate = DateTime.Compare(DateTime.Now, dateTime) >= 0;
                return isValidate;
            }
            return false;
        }

    }
}