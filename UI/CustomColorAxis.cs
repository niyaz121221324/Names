using OxyPlot;
using OxyPlot.Axes;
using System;

namespace Names.UI;

public class CustomColorAxis : LinearAxis, IColorAxis
{
    public Func<double, OxyColor> GetColorFunc { get; init; }

    public OxyColor GetColor(int val)
    {
        return GetColorFunc(val);
    }

    public int GetPaletteIndex(double value)
    {
        return (int)value;
    }
}