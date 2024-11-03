using UnityEngine;

[System.Serializable]
public struct BoardSize
{
    public int rows;
    public int columns;
}

[System.Serializable]
public struct CellSize
{
    public int width;
    public int height;
}

[CreateAssetMenu(fileName = "NewGameConfig", menuName = "TapMatch/Game Config")]
public class GameConfig : ScriptableObject
{
    [Header("Board Settings")]
    public BoardSize boardSize = new BoardSize { rows = 7, columns = 7 };

    [Header("Cell Settings")]
    public CellSize cellSize = new CellSize { width = 1, height = 1 };

    [Header("Color Settings (Can edit runtime)")]
    public ColorPalette colorPalette;

    [Header("Item Falling Speed (Can edit runtime)")]
    public float itemFallingSpeed = 6.0f;

    [Header("Spawn Delay In Sec (Can edit runtime)")]
    public float itemSpawnDelay = 0.25f;

    [Header("Min Colors To Match")]
    public int minColorsToMatch = 1;
}