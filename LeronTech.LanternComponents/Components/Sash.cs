using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Enums;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class Sash : IComponent
    {
        public Sash(SashType type, int count)
        {
            Count = count;
            Type = type;
        }

        public SashType Type { get; }
        public int Count { get; }
        public double Price => GetPrice(Type);

        public double Calculate() => Price * Count;
        private double GetPrice(SashType type)
        {
            var prices = PriceData.GetInstance().GetPrices();

            switch (type)
            {
                case SashType.Sash10x12:
                    return prices.Sash10x12;
                case SashType.Sash10x13:
                    return prices.Sash10x13;
                case SashType.Sash10x14:
                    return prices.Sash10x14;
                case SashType.Sash10x15:
                    return prices.Sash10x15;
                case SashType.Sash12x12:
                    return prices.Sash12x12;
                case SashType.Sash15x15:
                    return prices.Sash15x15;
                case SashType.Sash20x20:
                    return prices.Sash20x20;
                default:
                    throw new ArgumentException();
            }
        }
    }
}