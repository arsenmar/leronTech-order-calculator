using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class Corner : IComponent
    {
        private readonly double mWidth;
        private readonly double mRoundLength;

        public Corner(double width, double roundLength)
        {
            mWidth = width;
            mRoundLength = roundLength;
        }

        public double Price => PriceData.GetInstance().GetPrices().Corner;

        public double Calculate() => Math.Ceiling(mWidth * mRoundLength * Price);
    }
}
