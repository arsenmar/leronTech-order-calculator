using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Enums;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class Polycarbonate : IComponent
    {
        public const double coefficient = 0.5;

        private readonly double mWidth;
        private readonly double mRoundLength;

        public Polycarbonate(double width, double roundLength, ComponentSize size)
        {
            mWidth = width;
            mRoundLength = roundLength;
            Size = size;
        }

        public ComponentSize Size { get; }
        public double Price => GetPrice(Size);

        public double Calculate() => Math.Ceiling(((mWidth + coefficient) * mRoundLength + mWidth) * Price);

        private double GetPrice(ComponentSize size)
        {
            var prices = PriceData.GetInstance().GetPrices();

            switch (size)
            {
                case ComponentSize.Small:
                    return prices.PolycarbonateSmall;
                case ComponentSize.Medium:
                    return prices.PolycarbonateMedium;
                case ComponentSize.Big:
                    return prices.PolycarbonateBig;
                case ComponentSize.Large:
                    return prices.PolycarbonateLarge;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
