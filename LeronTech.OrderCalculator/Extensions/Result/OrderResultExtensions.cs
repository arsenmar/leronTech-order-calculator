using System.Linq;

namespace LeronTech.OrderCalculator.Extensions.Result
{
    public static class OrderResultExtensions
    {
        public static double GetLanternWithoutSashesResult(this Order order) =>
            order.LanternTypes.Sum(t => t.GetLanternsResult());

        public static double GetLanternWithSashesResult(this Order order) =>
            order.LanternTypes.Sum(t => t.GetLanternsWithSashesResult());

        public static double GetAvtomationInEuroResult(this Order order) =>
            order.ExternalAvtomation.Sum(t => t.Value.Calculate());

        public static double GetAvtomationInRubResult(this Order order) => (order.RubInEur.HasValue
            ? order.ExternalAvtomation.Sum(t => t.Value.Calculate() * order.RubInEur.Value) : 0)
            + order.BuldokAvtomation.Sum(t => t.Value.Calculate());

        public static double GetOrderResult(this Order order) => 
            order.GetLanternWithSashesResult() + order.GetAvtomationInRubResult();

    }
}
