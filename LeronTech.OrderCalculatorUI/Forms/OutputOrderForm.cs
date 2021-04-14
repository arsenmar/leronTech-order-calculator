using LeronTech.OrderCalculator;
using LeronTech.OrderFileOutput.Outputters;
using LeronTech.OrderFileOutput.Outputters.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LeronTech.OrderCalculatorUI.Forms
{
    public partial class OutputOrderForm : Form
    {
        private Order _order = null;

        public OutputOrderForm(Order order)
        {
            InitializeComponent();
            _order = order;
        }

        string settingsPath = $"{Directory.GetCurrentDirectory()}/settings.ini";

        private void Form_Load(object sender, EventArgs e)
        {
            using (StreamReader sr = new StreamReader(settingsPath))
                PathC.Text = sr.ReadToEnd();
        }

        private void CreateReportButton_Click(object sender, EventArgs e)
        {
            var pathExists = Directory.Exists(PathC.Text);
            if (!pathExists)
            {
                MessageBox.Show("Некорректный путь выгрузки");
                return;
            }
            var filename = $"Заказ {DateTime.Now:yyMMdd_hhmmss}.xlsx";
            try
            {
                IOrderOutputter outputter = new OrderExcelOutputter();
                outputter.Output(_order, PathC.Text, $"Заказ {DateTime.Now:yyMMdd_hhmmss}.xlsx");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            try
            {
                Process.Start("explorer.exe", $"/select, {PathC.Text.TrimEnd('/', '\\')}\\{filename}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ChooseDirectoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();

            if (folderDialog.SelectedPath == "")
                return;

            PathC.Text = folderDialog.SelectedPath;
            CheckAndRewritePath();
        }

        private void CheckAndRewritePath()
        {
            string newPath = PathC.Text;
            bool write = false;
            using (StreamReader read_path = new StreamReader(settingsPath))
            {
                var oldPath = read_path.ReadToEnd();

                if (oldPath != newPath)
                    write = true;
            }
            if (write)
            {
                using (StreamWriter write_path = new StreamWriter(settingsPath, false))
                    write_path.Write(newPath);
            }
        }
    }
}
