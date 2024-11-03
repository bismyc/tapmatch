using UnityEngine;

public class RandomWeightedColor
{
    private ColorPalette ColorPalette;

    public RandomWeightedColor(ColorPalette colorPalette)
    {
        ColorPalette = colorPalette;
    }

    public CellColor GetColor()
    {
        float totalWeight = 0;
        foreach (var colorWeight in ColorPalette.colors)
        {
            totalWeight += colorWeight.weight;
        }

        float randomValue = Random.Range(0, totalWeight);
        foreach (var colorWeight in ColorPalette.colors)
        {
            if (randomValue < colorWeight.weight)
            {
                return colorWeight.color;
            }
            randomValue -= colorWeight.weight;
        }

        return CellColor.Red; // Default color if none selected (shouldn't happen with proper setup)
    }
}
