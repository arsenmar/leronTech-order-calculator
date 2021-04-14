using System;

namespace LeronTech.Common.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class EnumValueExplanationAttribute : Attribute
    {
        public string Explanation { get; }
        public string Key { get; }

        public EnumValueExplanationAttribute(string explanation, string key = null)
        {
            Explanation = explanation;
            Key = key;
        }
    }
}
