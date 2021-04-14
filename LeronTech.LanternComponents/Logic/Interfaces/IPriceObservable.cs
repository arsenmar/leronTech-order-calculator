using LeronTech.LanternComponents.Models;

namespace LeronTech.LanternComponents.Logic.Interfaces
{
    public interface IPriceObservable
    {
        void AddObserver(IPriceObserver observer);
        void RemoveObserver(IPriceObserver observer);
        void NotifyObservers();
    }
}
