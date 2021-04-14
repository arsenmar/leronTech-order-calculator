using LeronTech.LanternComponents.Logic;
using LeronTech.LanternComponents.Models;
using LeronTech.OrderCalculatorUI.Helpers;
using System;
using System.Windows.Forms;

namespace LeronTech.OrderCalculatorUI.Forms
{
    public partial class ChangePricesForm : Form
    {
        private readonly PriceData _priceData = null;

        public ChangePricesForm()
        {
            InitializeComponent();
            _priceData = PriceData.GetInstance();

            LoadPrices();
        }

        private void BtnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                SavePrices();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SavePrices() 
        {
            var prices = new ComponentPrices()
            {
                ProfileSmall = ParseHelper.ParsePositiveDouble(txbProfilePrice35.Text, lblProfile.Text),
                ProfileLarge = ParseHelper.ParsePositiveDouble(txbProfilePrice50.Text, lblProfile.Text),
                RigelSmall = ParseHelper.ParsePositiveDouble(txbRigelPrice35.Text, lblRigel.Text),
                RigelLarge = ParseHelper.ParsePositiveDouble(txbRigelPrice50.Text, lblRigel.Text),
                Covers = ParseHelper.ParsePositiveDouble(txbCoversPrice.Text, lblCovers.Text),
                Rubber = ParseHelper.ParsePositiveDouble(txbRubber1Price.Text, lblRubber.Text),
                Rubber2 = ParseHelper.ParsePositiveDouble(txbRubber2Price.Text, lblRubber.Text),
                BaseSmall = ParseHelper.ParsePositiveDouble(txbBaseSmallPrice.Text, lblBase.Text),
                BaseMedium = ParseHelper.ParsePositiveDouble(txbBaseMediumPrice.Text, lblBase.Text),
                BaseBig = ParseHelper.ParsePositiveDouble(txbBaseBigPrice.Text, lblBase.Text),
                PolycarbonateSmall = ParseHelper.ParsePositiveDouble(txbPolycarbonateSmallPrice.Text, lblPolycarbonate.Text),
                PolycarbonateMedium = ParseHelper.ParsePositiveDouble(txbPolycarbonateMediumPrice.Text, lblPolycarbonate.Text),
                PolycarbonateBig = ParseHelper.ParsePositiveDouble(txbPolycarbonateBigPrice.Text, lblPolycarbonate.Text),
                PolycarbonateLarge = ParseHelper.ParsePositiveDouble(txbPolycarbonateLargePrice.Text, lblPolycarbonate.Text),
                BaseJumpers = ParseHelper.ParsePositiveDouble(txbBaseJumpersPrice.Text, lblBaseJumpers.Text),
                GlassJumpers = ParseHelper.ParsePositiveDouble(txbGlassJumpersPrice.Text, lblGlassJumpers.Text),
                Corner = ParseHelper.ParsePositiveDouble(txbCornerPrice.Text, lblCorner.Text),
                UnderOpening = ParseHelper.ParsePositiveDouble(txbUnderOpeningPrice.Text, lblUnderOpening.Text),

                Sash10x12 = ParseHelper.ParsePositiveDouble(txbSash10x12Price.Text, lblSash10x12.Text),
                Sash10x13 = ParseHelper.ParsePositiveDouble(txbSash10x13Price.Text, lblSash10x13.Text),
                Sash10x14 = ParseHelper.ParsePositiveDouble(txbSash10x14Price.Text, lblSash10x14.Text),
                Sash10x15 = ParseHelper.ParsePositiveDouble(txbSash10x15Price.Text, lblSash10x15.Text),
                Sash12x12 = ParseHelper.ParsePositiveDouble(txbSash12x12Price.Text, lblSash12x12.Text),
                Sash15x15 = ParseHelper.ParsePositiveDouble(txbSash15x15Price.Text, lblSash15x15.Text),
                Sash20x20 = ParseHelper.ParsePositiveDouble(txbSash20x20Price.Text, lblSash20x20.Text),

                Drive230V750 = ParseHelper.ParsePositiveDouble(txbDrive230V750Price.Text, lblDrive230V750.Text),
                Drive230V550 = ParseHelper.ParsePositiveDouble(txbDrive230V550Price.Text, lblDrive230V550.Text),
                Drive55024V = ParseHelper.ParsePositiveDouble(txbDrive55024VPrice.Text, lblDrive55024V.Text),
                Drive75024V = ParseHelper.ParsePositiveDouble(txbDrive75024VPrice.Text, lblDrive75024V.Text),
                Drive550 = ParseHelper.ParsePositiveDouble(txbDrive550Price.Text, lblDrive550.Text),
                Drive750 = ParseHelper.ParsePositiveDouble(txbDrive750Price.Text, lblDrive750.Text),
                TransmissionTube = ParseHelper.ParsePositiveDouble(txbTransmissionTubePrice.Text, lblTransmissionTube.Text),
                ControlBlockM2134 = ParseHelper.ParsePositiveDouble(txbControlBlockM2134Price.Text, lblControlBlockM2134.Text),
                ControlBlockGNS10 = ParseHelper.ParsePositiveDouble(txbControlBlockGNS10Price.Text, lblControlBlockGNS10.Text),
                ControlBlockCF10 = ParseHelper.ParsePositiveDouble(txbControlBlockCF10Price.Text, lblControlBlockCF10.Text),
                Battery = ParseHelper.ParsePositiveDouble(txbBatteryPrice.Text, lblBattery.Text),
                Button = ParseHelper.ParsePositiveDouble(txbButtonPrice.Text, lblButton.Text),
                WindSensor = ParseHelper.ParsePositiveDouble(txbWindSensorPrice.Text, lblWindSensor.Text),
                RainSensor = ParseHelper.ParsePositiveDouble(txbRainSensorPrice.Text, lblRainSensor.Text),
                WeatherControlBlockPV1 = ParseHelper.ParsePositiveDouble(txbWeatherControlBlockPV1Price.Text, lblWeatherControlBlockPV1.Text),
                WeatherControlBlockPV2 = ParseHelper.ParsePositiveDouble(txbWeatherControlBlockPV2Price.Text, lblWeatherControlBlockPV2.Text),
                HiDrive50024V = ParseHelper.ParsePositiveDouble(txbHiDrive50024VPrice.Text, lblHiDrive50024V.Text),
                HiDrive500230V = ParseHelper.ParsePositiveDouble(txbHiDrive500230VPrice.Text, lblHiDrive500230V.Text),

                B20B = ParseHelper.ParsePositiveDouble(txbB20BPrice.Text, lblB20B.Text),
                B26B = ParseHelper.ParsePositiveDouble(txbB26BPrice.Text, lblB26B.Text),
                B40B = ParseHelper.ParsePositiveDouble(txbB40BPrice.Text, lblB40B.Text),
                RemoteControl5A = ParseHelper.ParsePositiveDouble(txbRemoteControl5APrice.Text, lblRemoteControl5A.Text),
                RemoteControl8A = ParseHelper.ParsePositiveDouble(txbRemoteControl8APrice.Text, lblRemoteControl8A.Text),
                RemoteControl16A = ParseHelper.ParsePositiveDouble(txbRemoteControl16APrice.Text, lblRemoteControl16A.Text),
                RemoteControl20A = ParseHelper.ParsePositiveDouble(txbRemoteControl20APrice.Text, lblRemoteControl20A.Text),
                SmokeExhaustButtons = ParseHelper.ParsePositiveDouble(txbSmokeExhaustButtonsPrice.Text, lblSmokeExhaustButtons.Text),
                VentillationButtons = ParseHelper.ParsePositiveDouble(txbVentillationButtonsPrice.Text, lblVentilationButtons.Text),
                VentillationRemoteControl = ParseHelper.ParsePositiveDouble(txbVentillationRemoteControlPrice.Text, lblVentilationRemoteControl.Text),
            };

            _priceData.SetPrices(prices);
        }

        private void LoadPrices() 
        {
            var prices = _priceData.GetPrices();

            txbProfilePrice35.Text = prices.ProfileSmall.ToString();
            txbProfilePrice50.Text = prices.ProfileLarge.ToString();
            txbRigelPrice35.Text = prices.RigelSmall.ToString();
            txbRigelPrice50.Text = prices.RigelLarge.ToString();
            txbCoversPrice.Text = prices.Covers.ToString();
            txbRubber1Price.Text = prices.Rubber.ToString();
            txbRubber2Price.Text = prices.Rubber2.ToString();
            txbBaseSmallPrice.Text = prices.BaseSmall.ToString();
            txbBaseMediumPrice.Text = prices.BaseMedium.ToString();
            txbBaseBigPrice.Text = prices.BaseBig.ToString();
            txbPolycarbonateSmallPrice.Text = prices.PolycarbonateSmall.ToString();
            txbPolycarbonateMediumPrice.Text = prices.PolycarbonateMedium.ToString();
            txbPolycarbonateBigPrice.Text = prices.PolycarbonateBig.ToString();
            txbPolycarbonateLargePrice.Text = prices.PolycarbonateLarge.ToString();
            txbBaseJumpersPrice.Text = prices.BaseJumpers.ToString();
            txbGlassJumpersPrice.Text = prices.GlassJumpers.ToString();
            txbCornerPrice.Text = prices.Corner.ToString();
            txbUnderOpeningPrice.Text = prices.UnderOpening.ToString();

            txbSash10x12Price.Text = prices.Sash10x12.ToString();
            txbSash10x13Price.Text = prices.Sash10x13.ToString();
            txbSash10x14Price.Text = prices.Sash10x14.ToString();
            txbSash10x15Price.Text = prices.Sash10x15.ToString();
            txbSash12x12Price.Text = prices.Sash12x12.ToString();
            txbSash15x15Price.Text = prices.Sash15x15.ToString();
            txbSash20x20Price.Text = prices.Sash20x20.ToString();

            txbDrive230V750Price.Text = prices.Drive230V750.ToString();
            txbDrive230V550Price.Text = prices.Drive230V550.ToString();
            txbDrive55024VPrice.Text = prices.Drive55024V.ToString();
            txbDrive75024VPrice.Text = prices.Drive75024V.ToString();
            txbDrive550Price.Text = prices.Drive550.ToString();
            txbDrive750Price.Text = prices.Drive750.ToString();
            txbTransmissionTubePrice.Text = prices.TransmissionTube.ToString();
            txbControlBlockM2134Price.Text = prices.ControlBlockM2134.ToString();
            txbControlBlockGNS10Price.Text = prices.ControlBlockGNS10.ToString();
            txbControlBlockCF10Price.Text = prices.ControlBlockCF10.ToString();
            txbBatteryPrice.Text = prices.Battery.ToString();
            txbButtonPrice.Text = prices.Button.ToString();
            txbWindSensorPrice.Text = prices.WindSensor.ToString();
            txbRainSensorPrice.Text = prices.RainSensor.ToString();
            txbWeatherControlBlockPV1Price.Text = prices.WeatherControlBlockPV1.ToString();
            txbWeatherControlBlockPV2Price.Text = prices.WeatherControlBlockPV2.ToString();
            txbHiDrive50024VPrice.Text = prices.HiDrive50024V.ToString();
            txbHiDrive500230VPrice.Text = prices.HiDrive500230V.ToString();

            txbB20BPrice.Text = prices.B20B.ToString();
            txbB26BPrice.Text = prices.B26B.ToString();
            txbB40BPrice.Text = prices.B40B.ToString();
            txbRemoteControl5APrice.Text = prices.RemoteControl5A.ToString();
            txbRemoteControl8APrice.Text = prices.RemoteControl8A.ToString();
            txbRemoteControl16APrice.Text = prices.RemoteControl16A.ToString();
            txbRemoteControl20APrice.Text = prices.RemoteControl20A.ToString();
            txbSmokeExhaustButtonsPrice.Text = prices.SmokeExhaustButtons.ToString();
            txbVentillationButtonsPrice.Text = prices.VentillationButtons.ToString();
            txbVentillationRemoteControlPrice.Text = prices.VentillationRemoteControl.ToString();

        }
    }
}
