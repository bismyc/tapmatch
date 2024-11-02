using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private (int rows, int columns) BoardSize = (7, 7);

    [SerializeField]
    private (int width, int height) CellSize = (1, 1);

    private Cell[,] _cells;
    public Cell[,] Cells => _cells;

    [SerializeField]
    private GameObject CellPrefab;

    public enum CellColor
    {
        Red,
        Blue,
        Green,
        Yellow,
        Purple
    }

    private System.Random random = new System.Random();

    private void Start()
    {
        
    }

    public void CreateCells()
    {
        _cells = new Cell[BoardSize.rows, BoardSize.columns];
        Vector2 pos = new Vector2(-BoardSize.columns / 2, BoardSize.rows / 2);

        for (int row = 0; row < BoardSize.rows; row++)
        {
            for (int column = 0; column < BoardSize.columns; column++)
            {
                Cells[row, column] = Instantiate(CellPrefab).GetComponent<Cell>();
                Cells[row, column].name = "Cell" + "_[" + row + "," + column + "]";
                Cells[row, column].transform.SetParent(this.transform);

                System.Array colors = System.Enum.GetValues(typeof(CellColor));

                CellColor randomColor = (CellColor)colors.GetValue(random.Next(colors.Length));

                Cells[row, column].SetColor(randomColor);

                Cells[row, column].SetPosition(pos);
                Cells[row, column].SetIndex((row, column));
                pos.x += CellSize.width;

            }
            pos.y -= CellSize.height;
            pos.x = -BoardSize.columns / 2;
        }

    }

}
