using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Enums;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class BuldokAvtomation : IComponent
    {
        public BuldokAvtomation(BuldokAvtomationType type, int count)
        {
            Count = count;
            Type = type;
        }

        public BuldokAvtomationType Type { get; }
        public int Count { get; }
        public double Price => GetPrice(Type);

        public double Calculate() => Price * Count;
        private double GetPrice(BuldokAvtomationType type)
        {
            var prices = PriceData.GetInstance().GetPrices();

            switch (type)
            {
                case BuldokAvtomationType.B20B:
                    return prices.B20B;
                case BuldokAvtomationType.B26B:
                    return prices.B26B;
                case BuldokAvtomationType.B40B:
                    return prices.B40B;
                case BuldokAvtomationType.RemoteControl5A:
                    return prices.RemoteControl5A;
                case BuldokAvtomationType.RemoteControl8A:
                    return prices.RemoteControl8A;
                case BuldokAvtomationType.RemoteControl16A:
                    return prices.RemoteControl16A;
                case BuldokAvtomationType.RemoteControl20A:
                    return prices.RemoteControl20A;
                case BuldokAvtomationType.SmokeExhaustButtons:
                    return prices.SmokeExhaustButtons;
                case BuldokAvtomationType.VentillationButtons:
                    return prices.VentillationButtons;
                case BuldokAvtomationType.VentillationRemoteControl:
                    return prices.VentillationRemoteControl;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
