using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Logic;

namespace LeronTech.LanternComponents.Components
{
    public class UnderOpening : IComponent
    {
        public double Price => PriceData.GetInstance().GetPrices().UnderOpening;

        public double Calculate() => Price;
    }
}
