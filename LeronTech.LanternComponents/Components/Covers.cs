using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class Covers : IComponent
    {
        public const double coefficient = 0.5;
        public const double coefficient2 = 1;

        private readonly double mWidth;
        private readonly double mRoundLength;

        public Covers(double width, double roundLength)
        {
            mWidth = width;
            mRoundLength = roundLength;
        }

        public double Price => PriceData.GetInstance().GetPrices().Covers;

        public double Calculate() => Math.Ceiling((mWidth + coefficient) * (mRoundLength + coefficient2) * Price);
    }
}
