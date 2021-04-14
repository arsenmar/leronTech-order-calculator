using LeronTech.LanternComponents.Components;
using LeronTech.LanternComponents.Enums;
using System.Collections.Generic;

namespace LeronTech.OrderCalculatorUI.Extensions
{
    public static class DictionaryExtensions
    {
        public static string GetSashResult(this Dictionary<SashType, Sash> sashes, SashType type)
        {
            if (sashes.TryGetValue(type, out var sash))
                return sash.Calculate().ToString();

            return "0";
        }

        public static string GetExternalAvtomationResult(this Dictionary<ExternalAvtomationType, ExternalAvtomation> avtomation, ExternalAvtomationType type, double? rubInEur = null)
        {
            if (!avtomation.TryGetValue(type, out var sash))
                return "0";

            var result = sash.Calculate();

            if (rubInEur.HasValue)
                return $"{(result * rubInEur)} р.";

            return result + " €";
        }

        public static string GetBuldokAvtomationResult(this Dictionary<BuldokAvtomationType, BuldokAvtomation> avtomation, BuldokAvtomationType type)
        {
            if (!avtomation.TryGetValue(type, out var sash))
                return "0";

            return $"{sash.Calculate()} р.";
        }
    }
}
