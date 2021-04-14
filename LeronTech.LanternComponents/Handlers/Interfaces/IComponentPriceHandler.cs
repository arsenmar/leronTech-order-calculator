using LeronTech.LanternComponents.Models;

namespace LeronTech.LanternComponents.Handlers.Interfaces
{
    public interface IComponentPriceHandler
    {
        ComponentPrices Get();
        void Update(ComponentPrices prices);
    }
}
