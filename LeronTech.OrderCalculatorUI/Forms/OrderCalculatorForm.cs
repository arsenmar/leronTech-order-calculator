using LeronTech.LanternComponents.Logic;
using LeronTech.OrderCalculator;
using LeronTech.OrderCalculator.Builders;
using LeronTech.OrderCalculatorUI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LeronTech.OrderCalculatorUI.Forms
{
    public partial class OrderCalculatorForm : Form
    {
        private Dictionary<TabPage, LanternTypeControl> _ctrlLanternTypesPages = null;
        private PriceData _priceData = null;

        private Order _order = null;

        public OrderCalculatorForm()
        {
            InitializeComponent();

            _ctrlLanternTypesPages = new Dictionary<TabPage, LanternTypeControl>
            {
                { tbpLanternType1, ctrlLanternType1 },
                { tbpLanternType2, ctrlLanternType2 },
                { tbpLanternType3, ctrlLanternType3 },
                { tbpLanternType4, ctrlLanternType4 },
                { tbpLanternType5, ctrlLanternType5 }
            };

            _priceData = PriceData.GetInstance();
            _ctrlLanternTypesPages.Values.ToList().ForEach(t => _priceData.AddObserver(t));
            _priceData.AddObserver(ctrlExternalAvtomation);
            _priceData.AddObserver(ctrlBuldokAvtomation);
            _priceData.NotifyObservers();

            foreach (var item in _ctrlLanternTypesPages)
                item.Value.SetName(item.Key.Text);
        }

        private int _maxLanternCount => _ctrlLanternTypesPages.Keys.Count;
        private int _lanternTypeCount => tbcLanternComponents.TabPages.Count - 2;

        private void OrderCalculatorForm_Load(object sender, EventArgs e)
        {

            ReloadTabPages(1);
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                _order = null;
                _priceData.NotifyObservers();
                ctrlFullyResult.DefaultOutput();

                var activeLanternTypes = _ctrlLanternTypesPages.Values.Take(_lanternTypeCount);
                var lanternTypes = activeLanternTypes.Select(c => new LanternType(c.GetLanternTypeInput()));

                var orderBuilder = new OrderBuilder(_maxLanternCount, ctrlExternalAvtomation.GetRubInEuro());

                foreach (var type in lanternTypes)
                    orderBuilder.AddLanternType(type);
                orderBuilder.AddExternalAvtomation(ctrlExternalAvtomation.GetAvtomationInput());
                orderBuilder.AddBuldokAvtomation(ctrlBuldokAvtomation.GetAvtomationInput());
                _order = orderBuilder.Build();

                foreach (var control in activeLanternTypes)
                    control.Output(lanternTypes.FirstOrDefault(t => t.Name == control.LanternTypeName));
                ctrlExternalAvtomation.Output(_order.ExternalAvtomation);
                ctrlBuldokAvtomation.Output(_order.BuldokAvtomation);
                ctrlFullyResult.Output(_order);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnChangeLanternTypeAmount_Click(object sender, EventArgs e)
        {
            using (ChangeLanternTypeCountForm form = new ChangeLanternTypeCountForm(_maxLanternCount))
            {
                var result = form.ShowDialog();

                if (result == DialogResult.OK)
                    ReloadTabPages(form.LanternTypeCount);
            }
        }

        private void BtnChangePrices_Click(object sender, EventArgs e)
        {
            using (ChangePricesForm form = new ChangePricesForm())
            {
                var result = form.ShowDialog();
            }
        }

        private void ReloadTabPages(int pagesCount)
        {
            for (int i = 0; i < _ctrlLanternTypesPages.Keys.Count; i++)
                tbcLanternComponents.TabPages.Remove(_ctrlLanternTypesPages.Keys.ToList()[i]);

            for (int i = 0; i < pagesCount; i++)
                tbcLanternComponents.TabPages.Insert(tbcLanternComponents.TabPages.Count - 2, _ctrlLanternTypesPages.Keys.ToList()[i]);

            tbcLanternComponents.SelectedTab = tbcLanternComponents.TabPages[0];
        }

        private void BtnReport_Click(object sender, EventArgs e)
        {
            if (_order == null)
            {
                MessageBox.Show("Для вывода отчета произведите расчет");
                return;
            }

            using (OutputOrderForm form = new OutputOrderForm(_order))
            {
                var result = form.ShowDialog();
            }
        }
    }
}
