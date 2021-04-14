using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Enums;
using LeronTech.LanternComponents.Logic;
using System;

namespace LeronTech.LanternComponents.Components
{
    public class ExternalAvtomation : IComponent
    {
        public ExternalAvtomation(ExternalAvtomationType type, int count)
        {
            Count = count;
            Type = type;
        }

        public ExternalAvtomationType Type { get; }
        public int Count { get; }
        public double Price => GetPrice(Type);

        public double Calculate() => Price * Count;
        private double GetPrice(ExternalAvtomationType type)
        {
            var prices = PriceData.GetInstance().GetPrices();

            switch (type)
            {
                case ExternalAvtomationType.Drive230V750:
                    return prices.Drive230V750;
                case ExternalAvtomationType.Drive230V550:
                    return prices.Drive230V550;
                case ExternalAvtomationType.Drive55024V:
                    return prices.Drive55024V;
                case ExternalAvtomationType.Drive75024V:
                    return prices.Drive75024V;
                case ExternalAvtomationType.Drive550:
                    return prices.Drive550;
                case ExternalAvtomationType.Drive750:
                    return prices.Drive750;
                case ExternalAvtomationType.TransmissionTube:
                    return prices.TransmissionTube;
                case ExternalAvtomationType.ControlBlockM2134:
                    return prices.ControlBlockM2134;
                case ExternalAvtomationType.ControlBlockGNS10:
                    return prices.ControlBlockGNS10;
                case ExternalAvtomationType.ControlBlockCF10:
                    return prices.ControlBlockCF10;
                case ExternalAvtomationType.Battery:
                    return prices.Battery;
                case ExternalAvtomationType.Button:
                    return prices.Button;
                case ExternalAvtomationType.WindSensor:
                    return prices.WindSensor;
                case ExternalAvtomationType.RainSensor:
                    return prices.RainSensor;
                case ExternalAvtomationType.WeatherControlBlockPV1:
                    return prices.WeatherControlBlockPV1;
                case ExternalAvtomationType.WeatherControlBlockPV2:
                    return prices.WeatherControlBlockPV2;
                case ExternalAvtomationType.HiDrive50024V:
                    return prices.HiDrive50024V;
                case ExternalAvtomationType.HiDrive500230V:
                    return prices.HiDrive500230V;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
