using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class BaseJumpers : IComponent
    {
        private readonly double mWidth;
        private readonly double mRoundLength;

        public BaseJumpers(double width, double roundLength)
        {
            mWidth = width;
            mRoundLength = roundLength;
        }

        public double Price => PriceData.GetInstance().GetPrices().BaseJumpers;

        public double Calculate() => Math.Ceiling(mWidth * (mRoundLength / 2) * Price);
    }
}
