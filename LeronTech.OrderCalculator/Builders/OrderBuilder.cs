using LeronTech.LanternComponents.Components;
using LeronTech.LanternComponents.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeronTech.OrderCalculator.Builders
{
    public class OrderBuilder
    {
        private Order order = new Order();
        private int mMaxLanterns;

        public OrderBuilder(int maxLanterns, double? rubInEuro)
        {
            mMaxLanterns = maxLanterns;
            order.RubInEur = rubInEuro;
        }

        public OrderBuilder AddLanternType(LanternType lanternType)
        {
            if (order.LanternTypes.Count > mMaxLanterns)
                throw new OverflowException();

            order.LanternTypes.Add(lanternType);

            return this;
        }

        public OrderBuilder AddExternalAvtomation(Dictionary<ExternalAvtomationType, int> avtomation)
        {
            if (avtomation == null)
                throw new Exception("Словарь автоматики уже заполнен");

            order.ExternalAvtomation = avtomation.ToDictionary(a => a.Key, a => new ExternalAvtomation(a.Key, a.Value));
            return this;
        }

        public OrderBuilder AddBuldokAvtomation(Dictionary<BuldokAvtomationType, int> avtomation)
        {
            if (avtomation == null)
                throw new Exception("Словарь автоматики уже заполнен");

            order.BuldokAvtomation = avtomation.ToDictionary(a => a.Key, a => new BuldokAvtomation(a.Key, a.Value));
            return this;
        }

        public Order Build() => order;
    }
}
