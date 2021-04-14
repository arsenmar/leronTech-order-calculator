using LeronTech.Common.Attributes;
using LeronTech.LanternComponents.Components;
using LeronTech.LanternComponents.Enums;
using LeronTech.OrderCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeronTech.OrderCalculator
{
    public class LanternType
    {
        public LanternType(LanternTypeInput input)
        {
            Name = input.Name;
            Width = input.Width;
            Length = input.Length;
            Height = input.Height;
            Percent = input.Percent;
            LanternsCount = input.LanternsCount;
            var perimeterResult = (input.Width + input.Length) * 2;
            Perimeter = perimeterResult;
            Profile = new Profile(input.Width, perimeterResult);
            Rigel = new Rigel(input.Width, RoundLength);
            Covers = new Covers(input.Width, RoundLength);
            Rubber = new Rubber(input.Width, RoundLength, perimeterResult);
            Polycarbonate = new Polycarbonate(input.Width, RoundLength, input.PolycarbonateSize);
            Screws = new Screws(input.ScrewsPrice);
            Base = new Base(perimeterResult, input.BaseSize);

            Sashes = new Dictionary<SashType, Sash>();
            ArbitrarySashes = new List<ArbitrarySash>();

            if(input.BaseJumpers)
                BaseJumpers = new BaseJumpers(input.Width, RoundLength);

            if(input.GlassJumpers)
                GlassJumpers = new GlassJumpers(RoundLength);
            
            if(input.Corner)
                Corner = new Corner(input.Width, RoundLength);

            if (input.UnderOpening)
                UnderOpening = new UnderOpening();

            Sashes = input.Sashes.ToDictionary(s => s.Key, s => new Sash(s.Key, s.Value));
            ArbitrarySashes = input.ArbitrarySashes;
        }

        [TableParameters(1)]
        public string Name { get; set; }
        [TableParameters("Ширина", 2)]
        public double Width { get; }
        [TableParameters("Длина", 3)]
        public double Length { get; }
        [TableParameters("Высота", 4)]
        public double Height { get; }
        public double RoundLength => Math.Ceiling(Length);

        [TableParameters("Процент", 19, " %")]
        public int Percent { get; }

        [TableParameters("Кол-во фонарей", 20, " шт.")]
        public int LanternsCount { get; }

        [TableParameters("Периметр", 6)]
        public double Perimeter { get; }

        [TableParameters("Профиль", 7)]
        public Profile Profile { get; }

        [TableParameters("Ригель", 8)]
        public Rigel Rigel { get; }

        [TableParameters("Крышки", 9)]
        public Covers Covers { get; }

        [TableParameters("Резина", 10)]
        public Rubber Rubber { get; }

        [TableParameters("Поликарбонат", 11)]
        public Polycarbonate Polycarbonate { get; }

        [TableParameters("Саморезы", 12)]
        public Screws Screws { get; }

        [TableParameters("Основание", 13)]
        public Base Base { get; }

        [TableParameters("Перемычки на основании", 14)]
        public BaseJumpers BaseJumpers { get; set; }

        [TableParameters("Перемычки на стекло", 15)]
        public GlassJumpers GlassJumpers { get; set; }

        [TableParameters("Уголок на дугу", 16)]
        public Corner Corner { get; set; }

        [TableParameters("Под открывание", 17)]
        public UnderOpening UnderOpening { get; set; }

        public Dictionary<SashType, Sash> Sashes { get; set; }
        public List<ArbitrarySash> ArbitrarySashes { get; set; }
    }
}
