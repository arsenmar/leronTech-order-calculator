using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Enums;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class Profile : IComponent
    {
        private readonly double mPerimeter;

        public Profile(double width, double perimeter)
        {
            mPerimeter = perimeter;
            Type = width > 3 ? ComponentType.Large : ComponentType.Small;
        }

        public ComponentType Type { get; }
        public double Price => GetPrice(Type);

        public double Calculate() => Math.Ceiling(mPerimeter * 1.1 * Price);

        private double GetPrice(ComponentType type)
        {
            var prices = PriceData.GetInstance().GetPrices();

            switch (type)
            {
                case ComponentType.Small:
                    return prices.ProfileSmall;
                case ComponentType.Large:
                    return prices.ProfileLarge;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
