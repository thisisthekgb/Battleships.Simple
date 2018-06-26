using System;
using System.Linq;
using System.ComponentModel;

namespace Battleships.Model.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// There are generic ways of doing this but for now just allow the enum
        /// to access its description property.
        /// </summary>
        /// <param name="enumVal"></param>
        /// <returns></returns>
        public static string Description(this Enum enumVal) 
        {
            var attrs = enumVal
                    .GetType()
                    .GetMember(enumVal.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attrs != null && attrs.Length > 0)
                return ((DescriptionAttribute)attrs[0]).Description;

            return enumVal.ToString();
        }
    }
}
