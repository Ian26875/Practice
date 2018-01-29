using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Validators
{
    public sealed class DateTimeRangeAttribute : ValidationAttribute
    {
        /// <summary>
        /// Gets or sets the minimum date time.
        /// </summary>
        /// <value>
        /// The minimum date time.
        /// </value>
        public DateTime MinDateTime { get; set; }
        /// <summary>
        /// Gets or sets the maximum date time.
        /// </summary>
        /// <value>
        /// The maximum date time.
        /// </value>
        public DateTime MaxDateTime { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeRangeAttribute"/> class.
        /// </summary>
        /// <param name="minDateTime">The minimum date time.</param>
        /// <param name="maxDateTime">The maximum date time.</param>
        public DateTimeRangeAttribute(DateTime minDateTime, DateTime maxDateTime)
        {
            this.MinDateTime = minDateTime;
            this.MaxDateTime = maxDateTime;
        }

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
                return MinDateTime <= dateTime && dateTime <= MaxDateTime;
            }
            return false;
        }
    }
}