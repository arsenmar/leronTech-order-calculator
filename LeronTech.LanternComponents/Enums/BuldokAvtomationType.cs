using LeronTech.Common.Attributes;

namespace LeronTech.LanternComponents.Enums
{
    public enum BuldokAvtomationType
    {
        [EnumValueExplanation("B20B 2A 750мм")]
        B20B,

        [EnumValueExplanation("B26B 2,6A 750мм")]
        B26B,

        [EnumValueExplanation("B40B 4A 750мм")]
        B40B,

        [EnumValueExplanation("Пульт управления 5А")]
        RemoteControl5A,

        [EnumValueExplanation("Пульт управления 8А")]
        RemoteControl8A,

        [EnumValueExplanation("Пульт управления 16А")]
        RemoteControl16A,

        [EnumValueExplanation("Пульт управления 20А")]
        RemoteControl20A,

        [EnumValueExplanation("Кнопки дымоудаления")]
        SmokeExhaustButtons,

        [EnumValueExplanation("Кнопки вентиляции")]
        VentillationButtons,

        [EnumValueExplanation("Пульт управления вент. с датч.")]
        VentillationRemoteControl,
    }
}
