using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Enums;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class Rigel : IComponent
    {
        public const double coefficient = 0.5;
        public const double coefficient2 = 1;

        private readonly double mWidth;
        private readonly double mRoundLength;

        public Rigel(double width, double roundLength)
        {
            mWidth = width;
            mRoundLength = roundLength;

            Type = width > 3 ? ComponentType.Large : ComponentType.Small;
        }

        public ComponentType Type { get; }
        public double Price => GetPrice(Type);

        public double Calculate() => Math.Ceiling((mWidth + coefficient) * (mRoundLength + coefficient2) * Price);

        private double GetPrice(ComponentType type)
        {
            var prices = PriceData.GetInstance().GetPrices();

            switch (type)
            {
                case ComponentType.Small:
                    return prices.RigelSmall;
                case ComponentType.Large:
                    return prices.RigelLarge;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
