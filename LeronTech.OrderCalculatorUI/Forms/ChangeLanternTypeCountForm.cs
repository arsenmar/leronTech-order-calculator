using System;
using System.Windows.Forms;

namespace LeronTech.OrderCalculatorUI.Forms
{
    public partial class ChangeLanternTypeCountForm : Form
    {
        private readonly int mMaxLanternTypeCount;

        public ChangeLanternTypeCountForm(int maxLanternTypeCount)
        {
            InitializeComponent();
            mMaxLanternTypeCount = maxLanternTypeCount;

            lblMaxLanternTypeCount.Text = "Макс. " + mMaxLanternTypeCount;
        }

        public int LanternTypeCount { get; private set; }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                ParseValue();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (OverflowException)
            {
                MessageBox.Show($"Максимальное значение - {mMaxLanternTypeCount} типов фонарей");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно введено значение");
                return;
            }
        }

        private void ParseValue()
        {
            if (!int.TryParse(txbLanternTypeCount.Text, out var pagesCount))
                throw new Exception();

            if (pagesCount > mMaxLanternTypeCount)
                throw new OverflowException();

            if (pagesCount < 1)
                throw new Exception();

            LanternTypeCount = pagesCount;
        }
    }
}
