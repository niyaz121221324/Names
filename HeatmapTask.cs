using System;

namespace Names;

internal static class HeatmapTask
{
    public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
    {
        string[] xLabels = new string[30]; // Дни месяца не учитывая первый
        string[] yLabels = new string[12]; // Число месяца

        SetValueToXAndYLabels(xLabels, yLabels);

        double[,] heatMap = CreateHeatMap(names, xLabels.Length, yLabels.Length); // Тепловая карта

        return new HeatmapData(
            "Пример карты интенсивностей",
            heatMap,
            xLabels,
            yLabels);
    }

    private static double[,] CreateHeatMap(NameData[] names, int rowsCount, int colsCount)
    {
        double[,] heatMap = new double[rowsCount, colsCount];

        for (int i = 0; i < names.Length; i++)
        {
            int dayOfBirth = names[i].BirthDate.Day;
            int monthOfBirth = names[i].BirthDate.Month;

            if (dayOfBirth > 1)
            {
                heatMap[dayOfBirth - 2, monthOfBirth - 1]++;
            }
        }

        return heatMap;
    }

    private static void SetValueToXAndYLabels(string[] xLabels, string[] yLabels)
    {
        if (xLabels == null || yLabels == null)
        {
            throw new ArgumentNullException("xLabels or yLabels cannot be null");
        }

        int maxLength = Math.Max(xLabels.Length, yLabels.Length);

        for (int i = 0; i < maxLength; i++)
        {
            if (i < xLabels.Length)
            {
                xLabels[i] = (i + 2).ToString();
            }

            if (i < yLabels.Length)
            {
                yLabels[i] = (i + 1).ToString();
            }
        }
    }
}