using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

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
    }
}
