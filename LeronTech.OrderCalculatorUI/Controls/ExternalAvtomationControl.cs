using LeronTech.Common.Extensions;
using LeronTech.LanternComponents.Components;
using LeronTech.LanternComponents.Enums;
using LeronTech.LanternComponents.Logic.Interfaces;
using LeronTech.LanternComponents.Models;
using LeronTech.OrderCalculatorUI.Extensions;
using LeronTech.OrderCalculatorUI.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LeronTech.OrderCalculatorUI.Controls
{
    public partial class ExternalAvtomationControl : UserControl, IPriceObserver
    {
        public ExternalAvtomationControl()
        {
            InitializeComponent();
        }

        public double? GetRubInEuro() => ParseHelper.ParseNotRequiredPositiveDouble(txbRubInEuro.Text, "Курс евро");

        public Dictionary<ExternalAvtomationType, int> GetAvtomationInput()
        {
            var result = new List<(ExternalAvtomationType type, int count)>();

            result.Add(TryGetAvtomation(ExternalAvtomationType.Drive230V750, txbDrive230V750Count.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.Drive230V550, txbDrive230V550Count.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.Drive55024V, txbDrive55024VCount.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.Drive75024V, txbDrive75024VCount.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.Drive550, txbDrive550Count.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.Drive750, txbDrive750Count.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.TransmissionTube, txbTransmissionTubeCount.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.ControlBlockM2134, txbControlBlockM2134Count.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.ControlBlockGNS10, txbControlBlockGNS10Count.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.ControlBlockCF10, txbControlBlockCF10Count.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.Battery, txbBatteryCount.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.Button, txbButtonCount.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.WindSensor, txbWindSensorCount.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.RainSensor, txbRainSensorCount.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.WeatherControlBlockPV1, txbWeatherControlBlockPV1Count.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.WeatherControlBlockPV2, txbWeatherControlBlockPV2Count.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.HiDrive50024V, txbHiDrive50024VCount.Text));
            result.Add(TryGetAvtomation(ExternalAvtomationType.HiDrive500230V, txbHiDrive500230VCount.Text));

            return result.Where(s => s.count != default).ToDictionary(s => s.type, s => s.count);
        }

        public void UpdatePrices(ComponentPrices prices) => DefaultOutput(prices);

        public void Output(Dictionary<ExternalAvtomationType, ExternalAvtomation> avtomation)
        {
            lblDrive230V750Result.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.Drive230V750, GetRubInEuro());
            lblDrive230V550Result.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.Drive230V550, GetRubInEuro());
            lblDrive55024VResult.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.Drive55024V, GetRubInEuro());
            lblDrive75024VResult.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.Drive75024V, GetRubInEuro());
            lblDrive550Result.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.Drive550, GetRubInEuro());
            lblDrive750Result.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.Drive750, GetRubInEuro());
            lblTransmissionTubeResult.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.TransmissionTube, GetRubInEuro());
            lblControlBlockM2134Result.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.ControlBlockM2134, GetRubInEuro());
            lblControlBlockGNS10Result.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.ControlBlockGNS10, GetRubInEuro());
            lblControlBlockCF10Result.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.ControlBlockCF10, GetRubInEuro());
            lblBatteryResult.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.Battery, GetRubInEuro());
            lblButtonResult.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.Button, GetRubInEuro());
            lblWindSensorResult.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.WindSensor, GetRubInEuro());
            lblRainSensorResult.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.RainSensor, GetRubInEuro());
            lblWeatherControlBlockPV1Result.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.WeatherControlBlockPV1, GetRubInEuro());
            lblWeatherControlBlockPV2Result.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.WeatherControlBlockPV2, GetRubInEuro());
            lblHiDrive50024VResult.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.HiDrive50024V, GetRubInEuro());
            lblHiDrive500230VResult.Text = avtomation.GetExternalAvtomationResult(ExternalAvtomationType.HiDrive500230V, GetRubInEuro());
        }

        public void DefaultOutput(ComponentPrices prices)
        {
            lblDrive230V750.Text = $"Привод (актив) 230V 750 - {prices.Drive230V750} € -";
            lblDrive230V550.Text = $"Привод (актив) 230V 550 - {prices.Drive230V550} € -";
            lblDrive55024V.Text = $"Привод (актив) 550 24V - {prices.Drive55024V} € -";
            lblDrive75024V.Text = $"Привод (актив) 750 24V - {prices.Drive75024V} € -";
            lblDrive550.Text = $"Привод (пассив) 550 - {prices.Drive550} € -";
            lblDrive750.Text = $"Привод (пассив) 750 - {prices.Drive750} € -";
            lblTransmissionTube.Text = $"Трубка передач - {prices.TransmissionTube} € -";
            lblControlBlockM2134.Text = $"Блок управления M2134 230V - {prices.ControlBlockM2134} € -";
            lblControlBlockGNS10.Text = $"Блок управления GNS 10-2 24V - {prices.ControlBlockGNS10} € -";
            lblControlBlockCF10.Text = $"Блок упр. электропр. CF10/2 24V - {prices.ControlBlockCF10} € -";
            lblBattery.Text = $"Аккумулятор - {prices.Battery} € -";
            lblButton.Text = $"Кнопка - {prices.Button} € -";
            lblWindSensor.Text = $"Датчик ветра RV - {prices.WindSensor} € -";
            lblRainSensor.Text = $"Датчик дождя SP1 - {prices.RainSensor} € -";
            lblWeatherControlBlockPV1.Text = $"Блок метеоконтроля PV1 230V - {prices.WeatherControlBlockPV1} € -";
            lblWeatherControlBlockPV2.Text = $"Блок метеоконтроля PV2 24V - {prices.WeatherControlBlockPV2} € -";
            lblHiDrive50024V.Text = $"Привод Hi-drive 500мм 24V - {prices.HiDrive50024V} € -";
            lblHiDrive500230V.Text = $"Привод Hi-drive 500мм 230V - {prices.HiDrive500230V} € -";
        }

        private (ExternalAvtomationType, int) TryGetAvtomation(ExternalAvtomationType type, string count)
        {
            var parsedCount = ParseHelper.ParseNotRequiredPositiveIntLanternComponent(count, type.GetExplanation(), "Автоматика");

            return (type, parsedCount);
        }
    }
}
