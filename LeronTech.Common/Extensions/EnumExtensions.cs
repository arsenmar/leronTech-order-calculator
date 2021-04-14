using LeronTech.Common.Attributes;
using LeronTech.Common.Models;
using System;
using System.Linq;
using System.Reflection;

namespace LeronTech.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetExplanation(this Enum value, string key = null)
        {
            var attributes = (EnumValueExplanationAttribute[])value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(EnumValueExplanationAttribute), false);

            return attributes.FirstOrDefault(a => a.Key == key)?.Explanation ?? value.ToString();
        }

        public static TableParametersModel GetTableParameters(this MemberInfo type)
        {
            var attributes = (TableParametersAttribute[])type
                .GetCustomAttributes(typeof(TableParametersAttribute), false);

            var attribute = attributes.FirstOrDefault();
            if (attribute == null)
                return null;

            return new TableParametersModel 
            { 
                Row = attribute.Row, 
                DisplayName = attribute.DisplayName, 
                Postfix = attribute.Postfix
            };
        }
    }
}
