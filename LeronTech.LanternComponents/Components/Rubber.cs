using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class Rubber : IComponent
    {
        public const double coefficient1 = 0.5;
        public const double coefficient2 = 1;
        public const double coefficient3 = 2;

        private readonly double mWidth;
        private readonly double mRoundLength;
        private readonly double mPerimeter;

        public Rubber(double width, double roundLength, double perimeter)
        {
            mWidth = width;
            mRoundLength = roundLength;
            mPerimeter = perimeter;
        }

        public double Price => PriceData.GetInstance().GetPrices().Rubber;
        public double Price2 => PriceData.GetInstance().GetPrices().Rubber2;

        public double Calculate() => Math.Ceiling((mWidth + coefficient1) * (mRoundLength + coefficient2) * coefficient3 * Price + (mPerimeter * 1.1) * Price2);
    }
}
