using LeronTech.LanternComponents.Components.Interfaces;

namespace LeronTech.LanternComponents.Components
{
    public class Screws : IComponent
    {
        public Screws(double value) => Price = value;

        public double Price { get; }

        public double Calculate() => Price;
    }
}
