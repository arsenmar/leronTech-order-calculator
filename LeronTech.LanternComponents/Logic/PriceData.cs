using LeronTech.LanternComponents.Handlers;
using LeronTech.LanternComponents.Handlers.Interfaces;
using LeronTech.LanternComponents.Logic.Interfaces;
using LeronTech.LanternComponents.Models;
using System.Collections.Generic;

namespace LeronTech.LanternComponents.Logic
{
    public class PriceData : IPriceObservable
    {
        private static PriceData _instance;

        private IComponentPriceHandler _componentPriceHandler = null;
        private List<IPriceObserver> _observers = null;
        private ComponentPrices _prices = null;

        private PriceData()
        {
            _componentPriceHandler = new ComponentPriceHandlerJSON();
            _observers = new List<IPriceObserver>();

            _prices = _componentPriceHandler.Get();
        }

        public static PriceData GetInstance()
        {
            if (_instance == null)
                _instance = new PriceData();

            return _instance;
        }

        public ComponentPrices GetPrices() => _prices;

        public void SetPrices(ComponentPrices prices)
        {
            _componentPriceHandler.Update(prices);
            _prices = prices;
            NotifyObservers();
        }

        public void AddObserver(IPriceObserver observer) => _observers.Add(observer);

        public void NotifyObservers() => _observers.ForEach(o => o.UpdatePrices(_prices));

        public void RemoveObserver(IPriceObserver observer) => _observers.Remove(observer);
    }
}
