using System;

namespace LeronTech.OrderCalculatorUI.Helpers
{
    public class ParseHelper
    {
        public static double ParsePositiveDouble(string value, string valueName)
        {
            if (int.TryParse(value, out var result) && result >= 0)
                return result;

            throw new ArgumentException($"Некорректно введено значение {valueName}");
        }

        public static double? ParseNotRequiredPositiveDouble(string value, string valueName, double? defaultValue = null)
        {
            if (string.IsNullOrEmpty(value))
                return defaultValue;

            if (int.TryParse(value, out var result) && result >= 0)
                return result;

            throw new ArgumentException($"Некорректно введено значение {valueName}");
        }

        public static double ParsePositiveDoubleLanternComponent(string value, string valueName, string lanternName)
        {
            if (double.TryParse(value, out var result) && result >= 0)
                return result;

            throw new ArgumentException(GetLanternComponentExceptionMessage(valueName, lanternName));
        }

        public static int ParsePositiveIntLanternComponent(string value, string valueName, string lanternName)
        {
            if (int.TryParse(value, out var result) && result >= 0)
                return result;

            throw new ArgumentException(GetLanternComponentExceptionMessage(valueName, lanternName));
        }

        public static double ParseNotRequiredPositiveDoubleLanternComponent(string value, string valueName, string lanternName, double defaultValue = 0)
        {
            if (string.IsNullOrEmpty(value))
                return defaultValue;

            if (double.TryParse(value, out var result) && result >= 0)
                return result;

            throw new ArgumentException(GetLanternComponentExceptionMessage(valueName, lanternName));
        }

        public static int ParseNotRequiredPositiveIntLanternComponent(string value, string valueName, string lanternName, int defaultValue = 0)
        {
            if (string.IsNullOrEmpty(value))
                return defaultValue;

            if (int.TryParse(value, out var result) && result >= 0)
                return result;

            throw new ArgumentException(GetLanternComponentExceptionMessage(valueName, lanternName));
        }

        private static string GetLanternComponentExceptionMessage(string valueName, string lanternName) =>
            $"Во вкладке \"{lanternName}\" некорректно введено значение {valueName}";
    }
}
