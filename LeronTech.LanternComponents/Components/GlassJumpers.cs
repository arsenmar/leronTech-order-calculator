using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class GlassJumpers : IComponent
    {
        public const double coefficient = 1.05;

        private readonly double mRoundLength;

        public GlassJumpers(double roundLength)
        {
            mRoundLength = roundLength;
        }

        public double Price => PriceData.GetInstance().GetPrices().GlassJumpers;

        public double Calculate() => Math.Ceiling(mRoundLength * coefficient * Price);
    }
}
