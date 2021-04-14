using LeronTech.LanternComponents.Components.Interfaces;

namespace LeronTech.LanternComponents.Components
{
    public class ArbitrarySash : IComponent
    {
        public ArbitrarySash(int count, double price)
        {
            Count = count;
            Price = price;
        }

        public double Count { get; }
        public double Price { get; }

        public double Calculate() => Price * Count;
    }
}
