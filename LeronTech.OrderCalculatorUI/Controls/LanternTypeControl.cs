using LeronTech.Common.Extensions;
using LeronTech.LanternComponents.Components;
using LeronTech.LanternComponents.Enums;
using LeronTech.LanternComponents.Logic.Interfaces;
using LeronTech.LanternComponents.Models;
using LeronTech.OrderCalculator;
using LeronTech.OrderCalculator.Extensions;
using LeronTech.OrderCalculator.Models;
using LeronTech.OrderCalculatorUI.Extensions;
using LeronTech.OrderCalculatorUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LeronTech.OrderCalculatorUI.Controls
{
    public partial class LanternTypeControl : UserControl, IPriceObserver
    {
        public string LanternTypeName { get; private set; }

        public LanternTypeControl()
        {
            InitializeComponent();
        }

        public void SetName(string name) => LanternTypeName = name;

        public LanternTypeInput GetLanternTypeInput()
        {
            return new LanternTypeInput
            {
                Name = LanternTypeName,
                Width = ParseHelper.ParsePositiveDoubleLanternComponent(txbWidthInput.Text, "Ширина", LanternTypeName),
                Length = ParseHelper.ParsePositiveDoubleLanternComponent(txbLengthInput.Text, "Длина", LanternTypeName),
                Height = ParseHelper.ParseNotRequiredPositiveDoubleLanternComponent(txbHeightInput.Text, "Высота", LanternTypeName),
                Percent = ParseHelper.ParseNotRequiredPositiveIntLanternComponent(txbPercentInput.Text, "Процент прибавления", LanternTypeName),
                LanternsCount = ParseHelper.ParseNotRequiredPositiveIntLanternComponent(txbLanternCountInput.Text, "Кол-во фонарей", LanternTypeName, 1),
                BaseSize = GetBaseSize(),
                PolycarbonateSize = GetPolycarbonateSize(),
                ScrewsPrice = ParseHelper.ParseNotRequiredPositiveIntLanternComponent(txbScrewsInput.Text, "Саморезы", LanternTypeName),
                BaseJumpers = chbBasejumpers.Checked,
                GlassJumpers = chbGlassjumpers.Checked,
                Corner = chbCorner.Checked,
                UnderOpening = chbUnderOpening.Checked,
                Sashes = GetSashes(),
                ArbitrarySashes = GetArbitrarySashes()
            };
        }

        public void UpdatePrices(ComponentPrices prices) => DefaultOutput(prices);

        public void DefaultOutput(ComponentPrices prices)
        {
            rbtPolycarbonateSmall.Text = prices.PolycarbonateSmall.ToString();
            rbtPolycarbonateMedium.Text = prices.PolycarbonateMedium.ToString();
            rbtPolycarbonateBig.Text = prices.PolycarbonateBig.ToString();
            rbtPolycarbonateLarge.Text = prices.PolycarbonateLarge.ToString();

            rbtBaseSmall.Text = prices.BaseSmall.ToString();
            rbtBaseMedium.Text = prices.BaseMedium.ToString();
            rbtBaseBig.Text = prices.BaseBig.ToString();

            chbUnderOpening.Text = $"Под открывание (+{prices.UnderOpening})";

            lblPerimeterResult.Text = "P = (B+L)*2";
            lblProfileResult.Text = "Профиль заходной N = (P+10%)*Xруб";
            lblRigelResult.Text = $"Ригель N = (B+{Rigel.coefficient})*(L+{Rigel.coefficient2})*Xруб";
            lblCoversResult.Text = $"Крышки = (B+{Covers.coefficient})*(L+{Covers.coefficient2})*{prices.Covers}руб";
            lblRubberResult.Text = $"Резина = (B+{Rubber.coefficient1})*(L+{Rubber.coefficient2})*{Rubber.coefficient3}*{prices.Rubber}руб+(P+10%)*{prices.Rubber2}руб";
            lblBaseResult.Text = "Основание = P/2.5*Xруб";
            lblScrewsResult.Text = "Саморезы = 0";
            lblPolycarbonateResult.Text = $"Поликар. = ((B+{Polycarbonate.coefficient})*L+B)*Хруб";

            lblBasejumpersResult.Text = $"Перем. на осн. = B*(1/2*L)*{prices.BaseJumpers}руб";
            lblGlassjumpersResult.Text = $"Перем. под стекло = L*{GlassJumpers.coefficient}*{prices.GlassJumpers}руб";
            lblCornerResult.Text = $"Уголок на дугу = B*L*{prices.Corner}руб";
            lblUnderOpeningResult.Text = "Под открывание = 0";

            lblSash10x12Result.Text = "0";
            lblSash10x13Result.Text = "0";
            lblSash10x14Result.Text = "0";
            lblSash10x15Result.Text = "0";
            lblSash12x12Result.Text = "0";
            lblSash15x15Result.Text = "0";
            lblSash20x20Result.Text = "0";

            lblLanternResult.Text = $"Фонарь = Сумма + %";
            lblLanternsResult.Text = $"Фонарь * кол-во";
            lblSashesResult.Text = $"Створки";
            lblLanternWithSashesResult.Text = $"Фонарь + створки";
            lblLanternsWithSashesResult.Text = $"(Фонарь + створки)*кол-во";
        }

        public void Output(LanternType lanternType)
        {
            lblPerimeterResult.Text = $"P = ({lanternType.Width}+{lanternType.Length})*2 = {lanternType.Perimeter}";
            lblProfileResult.Text = $"Профиль заходной {(int)lanternType.Profile.Type} = ({lanternType.Perimeter} + 10%)*{lanternType.Profile.Price} = {lanternType.Profile.Calculate()}";
            lblRigelResult.Text = $"Ригель {(int)lanternType.Rigel.Type} = ({lanternType.Width}+{Rigel.coefficient})*({lanternType.RoundLength}+{Rigel.coefficient2})*{lanternType.Rigel.Price}руб = {lanternType.Rigel.Calculate()}";
            lblCoversResult.Text = $"Крышки = ({lanternType.Width}+{Covers.coefficient})*({lanternType.RoundLength}+{Covers.coefficient2})*{lanternType.Covers.Price}руб = {lanternType.Covers.Calculate()}";
            lblRubberResult.Text = $"Резина = ({lanternType.Width}+{Rubber.coefficient1})*({lanternType.RoundLength}+{Rubber.coefficient2})*{Rubber.coefficient3}*{lanternType.Rubber.Price}руб+({lanternType.Perimeter}+10%)*{lanternType.Rubber.Price2}руб = {lanternType.Rubber.Calculate()}";
            lblBaseResult.Text = $"Основание = {lanternType.Perimeter}/{Base.coefficient}*{lanternType.Base.Price}руб = {lanternType.Base.Calculate()}";
            lblScrewsResult.Text = $"Саморезы = {lanternType.Screws.Calculate()}";
            lblPolycarbonateResult.Text = $"Полик. = (({lanternType.Width}+{Polycarbonate.coefficient})*{lanternType.RoundLength}+{lanternType.Width})*{lanternType.Polycarbonate.Price}руб = {lanternType.Polycarbonate.Calculate()}";

            if(lanternType.BaseJumpers != null)
                lblBasejumpersResult.Text = $"Перем. на осн. = {lanternType.Width}*(1/2*{lanternType.RoundLength})*{lanternType.BaseJumpers.Price}руб = {lanternType.BaseJumpers.Calculate()}";

            if (lanternType.GlassJumpers != null)
                lblGlassjumpersResult.Text = $"Перем. под стекло = {lanternType.RoundLength}*{GlassJumpers.coefficient}*{lanternType.GlassJumpers.Price}руб = {lanternType.GlassJumpers.Calculate()}";

            if (lanternType.Corner != null)
                lblCornerResult.Text = $"Уголок на дугу = {lanternType.Width}*{lanternType.RoundLength}*{lanternType.Corner.Price}руб = {lanternType.Corner.Calculate()}";

            if(lanternType.UnderOpening != null)
                lblUnderOpeningResult.Text = $"Под открывание = {lanternType.UnderOpening.Calculate()}";

            lblSash10x12Result.Text = lanternType.Sashes.GetSashResult(SashType.Sash10x12);
            lblSash10x13Result.Text = lanternType.Sashes.GetSashResult(SashType.Sash10x13);
            lblSash10x14Result.Text = lanternType.Sashes.GetSashResult(SashType.Sash10x14);
            lblSash10x15Result.Text = lanternType.Sashes.GetSashResult(SashType.Sash10x15);
            lblSash12x12Result.Text = lanternType.Sashes.GetSashResult(SashType.Sash12x12);
            lblSash15x15Result.Text = lanternType.Sashes.GetSashResult(SashType.Sash15x15);
            lblSash20x20Result.Text = lanternType.Sashes.GetSashResult(SashType.Sash20x20);

            lblLanternResult.Text = $"Фонарь = {lanternType.GetLanternSum()} + {lanternType.Percent}% = {lanternType.GetLanternResult()}";
            lblLanternsResult.Text = $"Фонарь * кол-во = {lanternType.GetLanternsResult()}";
            lblSashesResult.Text = $"Створки = {lanternType.GetSashesResult()}";
            lblLanternWithSashesResult.Text = $"Фонарь + створки = {lanternType.GetLanternWithSashesResult()}";
            lblLanternsWithSashesResult.Text = $"(Фонарь + створки)*кол-во = {lanternType.GetLanternsWithSashesResult()}";
            //lblArbitrarySash1Result.Text = lanternType.ArbitrarySashes.
        }

        private ComponentSize GetBaseSize()
        {
            if (rbtBaseSmall.Checked)
                return ComponentSize.Small;

            if (rbtBaseMedium.Checked)
                return ComponentSize.Medium;

            return ComponentSize.Big;
        }

        private ComponentSize GetPolycarbonateSize()
        {
            if (rbtPolycarbonateSmall.Checked)
                return ComponentSize.Small;

            if (rbtPolycarbonateMedium.Checked)
                return ComponentSize.Medium;

            if (rbtPolycarbonateBig.Checked)
                return ComponentSize.Big;

            return ComponentSize.Large;
        }

        private Dictionary<SashType, int> GetSashes()
        {
            var result = new List<(SashType type, int count)>();

            result.Add(TryGetSash(SashType.Sash10x12, txbSash10x12Count.Text));
            result.Add(TryGetSash(SashType.Sash10x13, txbSash10x13Count.Text));
            result.Add(TryGetSash(SashType.Sash10x14, txbSash10x14Count.Text));
            result.Add(TryGetSash(SashType.Sash10x15, txbSash10x15Count.Text));
            result.Add(TryGetSash(SashType.Sash12x12, txbSash12x12Count.Text));
            result.Add(TryGetSash(SashType.Sash15x15, txbSash15x15Count.Text));
            result.Add(TryGetSash(SashType.Sash20x20, txbSash20x20Count.Text));

            return result.Where(s => s.count != default).ToDictionary(s => s.type, s => s.count);
        }

        private List<ArbitrarySash> GetArbitrarySashes()
        {
            var result = new List<ArbitrarySash>();
            result.Add(TryGetArbitrarySashes(txbArbitrarySash1Count.Text, txbArbitrarySash1Price.Text));
            result.Add(TryGetArbitrarySashes(txbArbitrarySash2Count.Text, txbArbitrarySash2Price.Text));

            return result.Where(s => s.Count != default && s.Price != default).ToList();
        }

        private ArbitrarySash TryGetArbitrarySashes(string count, string price)
        {
            var parsedCount = ParseHelper.ParseNotRequiredPositiveIntLanternComponent(count, "Произвольная створка - кол-во", LanternTypeName);
            var parsedPrice = ParseHelper.ParseNotRequiredPositiveDoubleLanternComponent(price, "Произвольная створка - цена", LanternTypeName);
            if ((parsedCount == default && parsedPrice != default) 
                || (parsedCount != default && parsedPrice == default))
            {
                throw new ArgumentException("Не введено одно из значений для произвольной створки в фонаре " + LanternTypeName);
            }

            return new ArbitrarySash(parsedCount, parsedPrice);
        }

        private (SashType, int) TryGetSash(SashType type, string count)
        {
            var parsedCount = ParseHelper.ParseNotRequiredPositiveIntLanternComponent(count, type.GetExplanation(), LanternTypeName);

            return (type, parsedCount);
        }
    }
}
