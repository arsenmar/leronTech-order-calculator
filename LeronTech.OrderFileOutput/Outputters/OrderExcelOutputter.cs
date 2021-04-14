using LeronTech.Common.Extensions;
using LeronTech.LanternComponents.Components;
using LeronTech.LanternComponents.Components.Interfaces;
using LeronTech.LanternComponents.Enums;
using LeronTech.OrderCalculator;
using LeronTech.OrderCalculator.Extensions;
using LeronTech.OrderCalculator.Extensions.Result;
using LeronTech.OrderFileOutput.Outputters.Interfaces;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LeronTech.OrderFileOutput.Outputters
{
    public class OrderExcelOutputter : IOrderOutputter
    {
        public void Output(Order order, string path, string filename)
        {
            Application ex = new Application();
            ex.Workbooks.Add();
            _Worksheet workSheet = (Worksheet)ex.ActiveSheet;

            var rows = DisplayHeaders(workSheet);

            for (int i = 0, col = 2; i < order.LanternTypes.Count; i++, col++)
                DisplayLanternResults(workSheet, order.LanternTypes[i], col, rows.arbitrarySashStartRow, rows.resultStartRow);

            DisplayAvtomation(workSheet, order.ExternalAvtomation, order.RubInEur, order.BuldokAvtomation, 1);

            workSheet.Cells[42, 2] = order.GetLanternWithoutSashesResult();
            workSheet.Cells[43, 2] = order.GetLanternWithSashesResult();
            workSheet.Cells[44, 2] = order.GetAvtomationInEuroResult();
            workSheet.Cells[45, 2] = order.GetAvtomationInRubResult();
            workSheet.Cells[46, 2] = order.GetOrderResult();

            ex.ActiveWorkbook.SaveAs(
                path.Last() == '/' || path.Last() == '\\'
                    ? $"{path}{filename}"
                    : $"{path}/{filename}",
                AccessMode: XlSaveAsAccessMode.xlShared,
                ReadOnlyRecommended: false);

            ex.Quit();
        }

        private void DisplayAvtomation(_Worksheet workSheet, Dictionary<ExternalAvtomationType, ExternalAvtomation> avtomation, double? rubInEur, Dictionary<BuldokAvtomationType, BuldokAvtomation> buldokAvtomation, int startRow)
        {
            int rowCounter = startRow;

            foreach (var item in avtomation)
            {
                workSheet.Cells[rowCounter, 9] = item.Key.GetExplanation() + $" - {item.Value.Count} шт.";
                var result = item.Value.Calculate();
                workSheet.Cells[rowCounter++, 10] = rubInEur.HasValue ? $"{result * rubInEur} руб." : $"{result} евро";
            }

            rowCounter++;

            foreach (var item in buldokAvtomation)
            {
                workSheet.Cells[rowCounter, 9] = item.Key.GetExplanation() + $" - {item.Value.Count} шт.";
                var result = item.Value.Calculate();
                workSheet.Cells[rowCounter++, 10] = $"{result} руб.";
            }

            var headers = (Range)workSheet.Columns[9];
            headers.Font.Bold = true;
            headers.Font.Size = 12;
            headers.AutoFit();

            var items = (Range)workSheet.Columns[10];
            items.AutoFit();
        }

        private void DisplayLanternResults(_Worksheet workSheet, LanternType lanternType, int col, int arbitrarySashStartRow, int resultStartRow)
        {
            foreach (var field in lanternType.GetType().GetProperties())
            {
                var value = field.GetValue(lanternType);
                if (value == null)
                    continue;
                var component = value as IComponent;
                var parameters = field.GetTableParameters();
                if (parameters != null)
                    workSheet.Cells[parameters.Row, col] = (component != null ? component.Calculate() : value).ToString() + parameters.Postfix;
            }

            foreach (var item in lanternType.Sashes)
            {
                var parameters = item.Key.GetType().GetField(item.Key.ToString()).GetTableParameters();
                if (parameters != null)
                    workSheet.Cells[parameters.Row, col] = $"{item.Value.Count}*{item.Value.Price} = {item.Value.Calculate()}";
            }

            int i = 0;
            foreach (var item in lanternType.ArbitrarySashes)
            {
                workSheet.Cells[arbitrarySashStartRow, "A"] = $"Произвольная створка {i++}";
                workSheet.Cells[arbitrarySashStartRow++, col] = item.Calculate();
            }

            workSheet.Cells[resultStartRow++, col] = lanternType.GetSashesResult();
            resultStartRow++;
            workSheet.Cells[resultStartRow++, col] = lanternType.GetLanternSum();
            workSheet.Cells[resultStartRow++, col] = lanternType.GetLanternResult();
            workSheet.Cells[resultStartRow++, col] = lanternType.GetLanternsResult();
            workSheet.Cells[resultStartRow++, col] = lanternType.GetLanternWithSashesResult();
            workSheet.Cells[resultStartRow++, col] = lanternType.GetLanternsWithSashesResult();

            var range = (Range)workSheet.Columns[col];
            range.AutoFit();
        }

        private (int arbitrarySashStartRow, int resultStartRow) DisplayHeaders(_Worksheet workSheet)
        {
            foreach (var field in typeof(LanternType).GetProperties())
            {
                var parameters = field.GetTableParameters();
                if (parameters != null)
                    workSheet.Cells[parameters.Row, "A"] = parameters.DisplayName;
            }

            int lastRow = 0;
            foreach (var item in Enum.GetValues(typeof(SashType)).Cast<SashType>())
            {
                var parameters = item.GetType().GetField(item.ToString()).GetTableParameters();
                if (parameters != null)
                {
                    workSheet.Cells[parameters.Row, "A"] = item.GetExplanation();
                    lastRow = lastRow < parameters.Row ? parameters.Row : lastRow;
                }
            }

            lastRow++;
            lastRow++;

            var arbitrarySashStartRow = lastRow;
            for (int i = 1; i <= 2; i++)
                workSheet.Cells[lastRow++, "A"] = $"Произвольная створка {i}";

            lastRow++;

            var resultStartRow = lastRow;
            workSheet.Cells[lastRow++, "A"] = "Створки";
            lastRow++;
            workSheet.Cells[lastRow++, "A"] = "Фонарь без процента";
            workSheet.Cells[lastRow++, "A"] = "Фонарь";
            workSheet.Cells[lastRow++, "A"] = "Фонарь * кол-во";
            workSheet.Cells[lastRow++, "A"] = "Фонарь + створки";
            workSheet.Cells[lastRow++, "A"] = "(Фонарь + створки) * кол-во";

            workSheet.Cells[42, "A"] = "Фонари без створок";
            workSheet.Cells[43, "A"] = "Фонари со створками";
            workSheet.Cells[44, "A"] = "Автоматика в евро";
            workSheet.Cells[45, "A"] = "Автоматика в рублях";
            workSheet.Cells[46, "A"] = "Весь заказ";

            var rangeHeaders = (Range)workSheet.Columns["A"];
            rangeHeaders.Font.Bold = true;
            rangeHeaders.Font.Size = 12;
            rangeHeaders.AutoFit();

            return (arbitrarySashStartRow, resultStartRow);
        }
    }
}