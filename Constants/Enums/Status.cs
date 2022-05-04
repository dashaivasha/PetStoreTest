using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace PetStore6.Constants.Enums
{
    public static class Statues
    {
        public enum Status
        {
            [Description("available")]
            Available,
            [Description("pending")]
            Pending,
            [Description("sold")]
            Sold
        }

        public static string GetDescription(this Enum genericEnum)
        {
            var genericEnumType = genericEnum.GetType();
            MemberInfo[] memberInfo = genericEnumType.GetMember(genericEnum.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attribs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attribs != null && attribs.Count() > 0)
                {
                    return ((DescriptionAttribute)attribs.ElementAt(0)).Description;
                }
            }

            return genericEnum.ToString();
        }
    }
}
