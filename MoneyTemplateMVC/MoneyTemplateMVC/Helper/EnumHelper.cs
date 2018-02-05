using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoneyTemplateMVC.Helper
{
    /// <summary>
    /// Enum Helper
    /// </summary>
    public static class EnumHelper
    {

        /// <summary>
        /// Parses the enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static T ParseEnum<T>(this int value)
        {
            T result=(T)System.Enum.Parse(typeof(T), value.ToString());
            return result;
        }
    }
}