using LeronTech.OrderCalculator;
using LeronTech.OrderCalculator.Extensions;
using LeronTech.OrderCalculator.Extensions.Result;
using System.Linq;
using System.Windows.Forms;

namespace LeronTech.OrderCalculatorUI.Controls
{
    public partial class FullyResultControl : UserControl
    {
        public FullyResultControl()
        {
            InitializeComponent();
        }

        public void Output(Order order)
        {
            lblLanternTypesWithoutSashesResult.Text = $"Фонари без створок = {order.LanternTypes.Sum(t => t.GetLanternsResult())}";
            lblLanternTypesWithSashesResult.Text = $"Фонари со створками = {order.LanternTypes.Sum(t => t.GetLanternsWithSashesResult())}";
            lblAvtomationInEuroResult.Text = $"Автоматика в евро = {order.GetAvtomationInEuroResult()}";
            lblAvtomationInRubResult.Text = $"Автоматика в рублях = {order.GetAvtomationInRubResult()}";
            lblFullyResult.Text = $"Весь заказ = {order.LanternTypes.Sum(t => t.GetLanternsWithSashesResult())} + {order.GetAvtomationInRubResult()} = {order.GetOrderResult()}";
        }

        public void DefaultOutput()
        {
            lblLanternTypesWithoutSashesResult.Text = $"Фонари без створок";
            lblLanternTypesWithSashesResult.Text = $"Фонари со створками";
            lblAvtomationInEuroResult.Text = $"Автоматика в евро";
            lblAvtomationInRubResult.Text = $"Автоматика в рублях";
            lblFullyResult.Text = $"Весь заказ = Фонари со створками + автоматика в рублях";
        }
    }
}
