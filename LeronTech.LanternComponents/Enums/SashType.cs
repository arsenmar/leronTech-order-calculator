using LeronTech.Common.Attributes;

namespace LeronTech.LanternComponents.Enums
{
    public enum SashType
    {
        [EnumValueExplanation("Створка 1,0х1,2м - 10400руб")]
        [TableParameters(22)]
        Sash10x12 = 1,

        [EnumValueExplanation("Створка 1,0х1,3м - 10900руб")]
        [TableParameters(23)]
        Sash10x13 = 2,

        [EnumValueExplanation("Створка 1,0х1,4м - 11450руб")]
        [TableParameters(24)]
        Sash10x14 = 3,

        [EnumValueExplanation("Створка 1,0х1,5м - 12500руб")]
        [TableParameters(25)]
        Sash10x15 = 4,

        [EnumValueExplanation("Створка 1,2х1,2м - 11450руб")]
        [TableParameters(26)]
        Sash12x12 = 5,

        [EnumValueExplanation("Створка 1,5х1,5м - 13500руб")]
        [TableParameters(27)]
        Sash15x15 = 6,

        [EnumValueExplanation("Створка 2,0х2,0м - 14500 руб")]
        [TableParameters(28)]
        Sash20x20 = 7
    }
}
