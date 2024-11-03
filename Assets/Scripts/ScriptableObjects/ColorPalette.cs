using UnityEngine;

public enum CellColor
{
    Red,
    Blue,
    Green,
    Yellow,
    Purple
}

[System.Serializable]
public class ColorWeight
{
    public CellColor color;
    public float weight; // Higher weight means higher probability of being selected
}

[CreateAssetMenu(fileName = "NewColorPalette", menuName = "TapMatch/Color Palette")]
public class ColorPalette : ScriptableObject
{
    public ColorWeight[] colors;
}
