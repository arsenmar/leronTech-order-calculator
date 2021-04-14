using LeronTech.Common.Attributes;

namespace LeronTech.LanternComponents.Enums
{
    public enum ExternalAvtomationType
    {
        [EnumValueExplanation("Привод (актив) 230V 750")]
        Drive230V750 = 1,

        [EnumValueExplanation("Привод (актив) 230V 550")]
        Drive230V550,

        [EnumValueExplanation("Привод (актив) 550 24V")]
        Drive55024V,

        [EnumValueExplanation("Привод (актив) 750 24V")]
        Drive75024V,

        [EnumValueExplanation("Привод (пассив) 550")]
        Drive550,

        [EnumValueExplanation("Привод (пассив) 750")]
        Drive750,

        [EnumValueExplanation("Трубка передач")]
        TransmissionTube,

        [EnumValueExplanation("Блок управления M2134 230V")]
        ControlBlockM2134,

        [EnumValueExplanation("Блок управления GNS 10-2 24V")]
        ControlBlockGNS10,

        [EnumValueExplanation("Блок упр. электропр. CF10/2 24V")]
        ControlBlockCF10,

        [EnumValueExplanation("Аккумулятор")]
        Battery,

        [EnumValueExplanation("Кнопка")]
        Button,

        [EnumValueExplanation("Датчик ветра RV")]
        WindSensor,

        [EnumValueExplanation("Датчик дождя SP1")]
        RainSensor,

        [EnumValueExplanation("Блок метеоконтроля PV1 230V")]
        WeatherControlBlockPV1,

        [EnumValueExplanation("Блок метеоконтроля PV2 24V")]
        WeatherControlBlockPV2,

        [EnumValueExplanation("Привод Hi-drive 500мм 24V")]
        HiDrive50024V,

        [EnumValueExplanation("Привод Hi-drive 500мм 230V")]
        HiDrive500230V
    }
}
