using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Enums;
using LeronTech.LanternComponents.Handlers;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class Base : IComponent
    {
        public const double coefficient = 2.5;
        private readonly double mPerimeter;

        public Base(double perimeter, ComponentSize size)
        {
            mPerimeter = perimeter;
            Size = size;
        }

        public ComponentSize Size { get; }
        public double Price => GetPrice(Size);

        public double Calculate() => Math.Ceiling(mPerimeter / coefficient) * Price;
        private double GetPrice(ComponentSize size)
        {
            var prices = PriceData.GetInstance().GetPrices();

            switch (size)
            {
                case ComponentSize.Small:
                    return prices.BaseSmall;
                case ComponentSize.Medium:
                    return prices.BaseMedium;
                case ComponentSize.Big:
                    return prices.BaseBig;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
