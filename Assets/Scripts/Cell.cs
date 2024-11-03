using UnityEngine;

public class Cell : MonoBehaviour
{
    [SerializeField]
    public (int row, int col) Index { get; private set; }

    public void SetColor(Board.CellColor color)
    {
        Item item = GetComponentInChildren<Item>();
        UnityEngine.Assertions.Assert.IsNotNull(item, "Item is missing.");

        if(item != null)
        {
            item.SetColor(color);
        }

    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void SetIndex((int row, int col) index)
    {
        Index = index;
        transform.name = "Cell" + "_[" + index.row + "," + index.col + "]";
    }

    public Item GetItem()
    {
        return GetComponentInChildren<Item>();
    }


}
