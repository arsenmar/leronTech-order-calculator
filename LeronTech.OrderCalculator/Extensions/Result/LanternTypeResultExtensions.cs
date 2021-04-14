using System.Linq;

namespace LeronTech.OrderCalculator.Extensions
{
    public static class LanternTypeResultExtensions
    {
        public static double GetLanternSum(this LanternType type)
        {
            return type.Profile.Calculate() + type.Rigel.Calculate() + type.Covers.Calculate() +
                type.Rubber.Calculate() + type.Polycarbonate.Calculate() +
                type.Screws.Calculate() + type.Base.Calculate() +
                ((type.BaseJumpers?.Calculate()) ?? 0) +
                ((type.GlassJumpers?.Calculate()) ?? 0) +
                ((type.Corner?.Calculate()) ?? 0) +
                ((type.UnderOpening?.Calculate()) ?? 0);
        }
        public static double GetLanternResult(this LanternType type)
        {
            var lanternSum = type.GetLanternSum();
            return lanternSum + (type.Percent / 100d * lanternSum);
        }
        public static double GetLanternsResult(this LanternType type) => type.GetLanternResult() * type.LanternsCount;
        public static double GetSashesResult(this LanternType type) => (type.Sashes?.Sum(s => s.Value.Calculate()) + type.ArbitrarySashes?.Sum(s => s.Calculate())) ?? 0;
        public static double GetLanternWithSashesResult(this LanternType type) => type.GetLanternResult() + type.GetSashesResult();
        public static double GetLanternsWithSashesResult(this LanternType type) => type.GetLanternWithSashesResult() * type.LanternsCount;

    }
}
