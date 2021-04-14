using LeronTech.LanternComponents.Components;
using LeronTech.LanternComponents.Enums;
using System.Collections.Generic;

namespace LeronTech.OrderCalculator.Models
{
    public class LanternTypeInput
    {
        public string Name { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double Height { get; set; }
        public double ScrewsPrice { get; set; }
        public ComponentSize BaseSize { get; set; }
        public ComponentSize PolycarbonateSize { get; set; }
        public int Percent { get; set; }
        public int LanternsCount { get; set; }
        public bool BaseJumpers { get; set; }
        public bool GlassJumpers { get; set; }
        public bool Corner { get; set; }
        public bool UnderOpening { get; set; }
        public Dictionary<SashType, int> Sashes { get; set; }
        public List<ArbitrarySash> ArbitrarySashes { get; set; }
    }
}
