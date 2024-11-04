using UnityEngine;

[System.Serializable]
public struct BoardSize
{
    public int rows;
    public int columns;
}

[CreateAssetMenu(fileName = "NewGameConfig", menuName = "TapMatch/Game Config")]
public class GameConfig : ScriptableObject
{
    [Header("Board Settings")]
    public BoardSize boardSize = new BoardSize { rows = 7, columns = 7 };

    [Header("Cell Size")]
    public int cellSize = 1;

    [Header("Min Colors To Match")]
    public int minColorsToMatch = 1;

    [Header("Color Settings (Can edit runtime)")]
    public ColorPalette colorPalette;

    [Header("Item Falling Speed (Can edit runtime)")]
    public float itemFallingSpeed = 6.0f;

    [Header("Spawn Delay In Sec (Can edit runtime)")]
    public float itemSpawnDelay = 0.25f;

}