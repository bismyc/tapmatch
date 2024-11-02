using UnityEngine;

public class Cell : MonoBehaviour
{
    public Board.CellColor MyColor { get; private set; }
    public (int row, int col) Index { get; private set; }

    public void SetColor(Board.CellColor color)
    {
        Renderer renderer = GetComponent<Renderer>();
        UnityEngine.Assertions.Assert.IsNotNull(renderer, "Renderer is missing.");

        if(renderer != null)
        {
            MyColor = color;
            switch (color)
            {
                case Board.CellColor.Red:
                    renderer.material.color = Color.red;
                    break;
                case Board.CellColor.Blue:
                    renderer.material.color = Color.blue;
                    break;
                case Board.CellColor.Green:
                    renderer.material.color = Color.green;
                    break;
                case Board.CellColor.Yellow:
                    renderer.material.color = Color.yellow;
                    break;
                case Board.CellColor.Purple:
                    renderer.material.color = new Color(0.5f, 0f, 0.5f); // Approximate purple
                    break;
                default:
                    renderer.material.color = Color.white;
                    break;
            }
        }

    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void SetIndex((int row, int col) index)
    {
        Index = index;
    }
}
