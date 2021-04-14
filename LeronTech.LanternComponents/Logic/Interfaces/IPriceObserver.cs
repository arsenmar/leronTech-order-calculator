using LeronTech.LanternComponents.Models;

namespace LeronTech.LanternComponents.Logic.Interfaces
{
    public interface IPriceObserver
    {
        void UpdatePrices(ComponentPrices prices);
    }
}
