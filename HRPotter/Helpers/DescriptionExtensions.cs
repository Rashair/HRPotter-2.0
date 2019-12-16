using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace HRPotter.Helpers
{
    public static class DescriptionExtensions

    {
        public static string GetDescription(this bool b)
        {
            return b ? "&#x2714;" : "&#x2716;";
        }


        // https://stackoverflow.com/a/479417
        public static string GetDescription(this Enum e)
        {
            MemberInfo[] memberInfo = e.GetType().GetMember(e.ToString());
            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return e.ToString();
        }

        // https://stackoverflow.com/a/15768915/6841224
        public static IEnumerable<SelectListItem> GetEnumSelectList<T>() where T : Enum
        {
            foreach (T obj in Enum.GetValues(typeof(T)))
            {
                Enum enumObj = Enum.Parse(typeof(T), obj.ToString()) as Enum;
                int enumInt = Convert.ToInt32(enumObj, CultureInfo.InvariantCulture);
                yield return new SelectListItem()
                {
                    Value = enumInt.ToString(CultureInfo.InvariantCulture),
                    Text = enumObj.GetDescription()
                };
            }
        }
    }
}
