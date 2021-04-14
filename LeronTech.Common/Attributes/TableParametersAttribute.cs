using System;

namespace LeronTech.Common.Attributes
{
    public class TableParametersAttribute : Attribute
    {
        public string DisplayName { get; set; }
        public int Row { get; set; }
        public string Postfix { get; set; }
        public int? Color { get; set; }

        public TableParametersAttribute(int row, string postfix = null)
        {
            Row = row;
            Postfix = postfix;
        }

        public TableParametersAttribute(string displayName, int row, string postfix = null)
        {
            DisplayName = displayName;
            Row = row;
            Postfix = postfix;
        }
    }
}
