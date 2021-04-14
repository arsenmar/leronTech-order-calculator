using LeronTech.Common.Extensions;
using LeronTech.LanternComponents.Components;
using LeronTech.LanternComponents.Enums;
using LeronTech.LanternComponents.Logic.Interfaces;
using LeronTech.LanternComponents.Models;
using LeronTech.OrderCalculatorUI.Extensions;
using LeronTech.OrderCalculatorUI.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace LeronTech.OrderCalculatorUI.Controls
{
    public partial class BuldokAvtomationControl : UserControl, IPriceObserver
    {
        public BuldokAvtomationControl()
        {
            InitializeComponent();
        }

        public Dictionary<BuldokAvtomationType, int> GetAvtomationInput()
        {
            var result = new List<(BuldokAvtomationType type, int count)>();

            result.Add(TryGetAvtomation(BuldokAvtomationType.B20B, txbB20Count.Text));
            result.Add(TryGetAvtomation(BuldokAvtomationType.B26B, txbB26BCount.Text));
            result.Add(TryGetAvtomation(BuldokAvtomationType.B40B, txbB40BCount.Text));
            result.Add(TryGetAvtomation(BuldokAvtomationType.RemoteControl5A, txbRemoteControl5ACount.Text));
            result.Add(TryGetAvtomation(BuldokAvtomationType.RemoteControl8A, txbRemoteControl8ACount.Text));
            result.Add(TryGetAvtomation(BuldokAvtomationType.RemoteControl16A, txbRemoteControl16ACount.Text));
            result.Add(TryGetAvtomation(BuldokAvtomationType.RemoteControl20A, txbRemoteControl20ACount.Text));
            result.Add(TryGetAvtomation(BuldokAvtomationType.SmokeExhaustButtons, txbSmokeExhaustButtonsCount.Text));
            result.Add(TryGetAvtomation(BuldokAvtomationType.VentillationButtons, txbVentilationButtonsCount.Text));
            result.Add(TryGetAvtomation(BuldokAvtomationType.VentillationRemoteControl, txbVentilationRemoteControlCount.Text));

            return result.Where(s => s.count != default).ToDictionary(s => s.type, s => s.count);
        }

        public void UpdatePrices(ComponentPrices prices) => DefaultOutput(prices);

        public void Output(Dictionary<BuldokAvtomationType, BuldokAvtomation> avtomation)
        {
            lblB20BResult.Text = avtomation.GetBuldokAvtomationResult(BuldokAvtomationType.B20B);
            lblB26BResult.Text = avtomation.GetBuldokAvtomationResult(BuldokAvtomationType.B26B);
            lblB40BResult.Text = avtomation.GetBuldokAvtomationResult(BuldokAvtomationType.B40B);
            lblRemoteControl5AResult.Text = avtomation.GetBuldokAvtomationResult(BuldokAvtomationType.RemoteControl5A);
            lblRemoteControl8AResult.Text = avtomation.GetBuldokAvtomationResult(BuldokAvtomationType.RemoteControl8A);
            lblRemoteControl16AResult.Text = avtomation.GetBuldokAvtomationResult(BuldokAvtomationType.RemoteControl16A);
            lblRemoteControl20AResult.Text = avtomation.GetBuldokAvtomationResult(BuldokAvtomationType.RemoteControl20A);
            lblSmokeExhaustButtonsResult.Text = avtomation.GetBuldokAvtomationResult(BuldokAvtomationType.SmokeExhaustButtons);
            lblVentilationButtonsResult.Text = avtomation.GetBuldokAvtomationResult(BuldokAvtomationType.VentillationButtons);
            lblVentilationRemoteControlResult.Text = avtomation.GetBuldokAvtomationResult(BuldokAvtomationType.VentillationRemoteControl);
        }

        public void DefaultOutput(ComponentPrices prices)
        {
            lblB20B.Text = $"B20B 2A 750мм - {prices.B20B} р.";
            lblB26B.Text = $"B26B 2,6A 750мм - {prices.B26B} р.";
            lblB40B.Text = $"B40B 4A 750мм - {prices.B40B} р.";
            lblRemoteControl5A.Text = $"Пульт управления 5А - {prices.RemoteControl5A} р.";
            lblRemoteControl8A.Text = $"Пульт управления 8А - {prices.RemoteControl8A} р.";
            lblRemoteControl16A.Text = $"Пульт управления 16А - {prices.RemoteControl16A} р.";
            lblRemoteControl20A.Text = $"Пульт управления 20А - {prices.RemoteControl20A} р.";
            lblSmokeExhaustButtons.Text = $"Кнопки дымоудаления - {prices.SmokeExhaustButtons} р.";
            lblVentilationButtons.Text = $"Кнопки вентиляции - {prices.VentillationButtons} р.";
            lblVentilationRemoteControl.Text = $"Пульт управления вент. с датч. - {prices.VentillationRemoteControl} р.";
        }

        private (BuldokAvtomationType, int) TryGetAvtomation(BuldokAvtomationType type, string count)
        {
            var parsedCount = ParseHelper.ParseNotRequiredPositiveIntLanternComponent(count, type.GetExplanation(), "Buldok");

            return (type, parsedCount);
        }
    }
}
