using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utility
{
    public static class Helper
    {
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            try
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
                if (attributes.Length > 0)
                {
                    return (T)attributes[0];
                }
                attributes = memberInfo[1].GetCustomAttributes(typeof(T), false);
                if (attributes.Length > 0)
                {
                    return (T)attributes[0];
                }
            }
            catch
            {
                return null;
            }

            return null;
        }
        public static string GetDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            if (attribute == null)
            {
                return string.Empty;
            }
            return attribute.Description;
        }
    }
}
