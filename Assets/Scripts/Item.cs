using UnityEngine;

public class Item : MonoBehaviour
{
    public CellColor MyColor { get; private set; }

    public void SetColor(CellColor color)
    {
        Renderer renderer = GetComponent<Renderer>();
        UnityEngine.Assertions.Assert.IsNotNull(renderer, "Renderer is missing.");

        if (renderer != null)
        {
            MyColor = color;
            switch (color)
            {
                case CellColor.Red:
                    renderer.material.color = Color.red;
                    break;
                case CellColor.Blue:
                    renderer.material.color = Color.blue;
                    break;
                case CellColor.Green:
                    renderer.material.color = Color.green;
                    break;
                case CellColor.Yellow:
                    renderer.material.color = Color.yellow;
                    break;
                case CellColor.Purple:
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

}
