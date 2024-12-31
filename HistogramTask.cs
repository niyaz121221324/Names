namespace Names;

internal static class HistogramTask
{
    public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
    {
        double[] yLabels = new double[31];
        string[] xLabels = new string[31];

        for (int i = 0; i < xLabels.Length; i++)
        {
            xLabels[i] = (i + 1).ToString();
        }

        for (int i = 0; i < names.Length; i++)
        {
            if (names[i].Name == name && names[i].BirthDate.Day > 1)
            {
                yLabels[names[i].BirthDate.Day - 1]++;
            }
        }

        return new HistogramData(
            $"Рождаемость людей с именем '{name}'",
            xLabels,
            yLabels);
    }
}