using LeronTech.OrderCalculator;

namespace LeronTech.OrderFileOutput.Outputters.Interfaces
{
    public interface IOrderOutputter
    {
        void Output(Order order, string path, string filename);
    }
}
