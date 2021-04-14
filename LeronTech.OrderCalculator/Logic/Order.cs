using LeronTech.LanternComponents.Components;
using LeronTech.LanternComponents.Enums;
using System.Collections.Generic;

namespace LeronTech.OrderCalculator
{
    public class Order
    {
        public Order()
        {
            LanternTypes = new List<LanternType>();
            ExternalAvtomation = new Dictionary<ExternalAvtomationType, ExternalAvtomation>();
        }

        public List<LanternType> LanternTypes { get; set; }
        public Dictionary<ExternalAvtomationType, ExternalAvtomation> ExternalAvtomation { get; set; }
        public Dictionary<BuldokAvtomationType, BuldokAvtomation> BuldokAvtomation { get; set; }
        public double? RubInEur { get; set; }
    }
}
