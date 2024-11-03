using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private (int rows, int columns) BoardSize = (7, 7);

    [SerializeField]
    private (int width, int height) CellSize = (1, 1);

    private Cell[,] Cells;

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

    public void CreateCells()
    {
        Cells = new Cell[BoardSize.rows, BoardSize.columns];
        Vector2 pos = new Vector2(-BoardSize.columns / 2, BoardSize.rows / 2);

        for (int row = 0; row < BoardSize.rows; row++)
        {
            for (int column = 0; column < BoardSize.columns; column++)
            {
                Cells[row, column] = Instantiate(CellPrefab).GetComponent<Cell>();
          
                Cells[row, column].transform.SetParent(this.transform);

                Array colors = Enum.GetValues(typeof(CellColor));

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

    public List<Item> FindMatchedCells(MatchFinder matchFinder, Cell tappedCell)
    {
        return matchFinder.BreadthFirstSearch(Cells, tappedCell);
    }

    public void DeactivateCells(List<Item> matchedItems)
    {
        foreach (Item item in matchedItems)
        {
            item.gameObject.SetActive(false);
            item.transform.SetParent(this.transform);
            item.SetPosition(new Vector2(item.transform.position.x, BoardSize.rows / 2 + 1));
        }
    }

    public void DropItemsToEmptyCells()
    {
        for (int col = 0; col < BoardSize.columns; col++)
        {
            for (int row = BoardSize.rows - 1; row >= 0; row--) // Start from the bottom of each column
            {
                if (Cells[row, col].GetItem() == null) // Check if the cell is empty
                {
                    // Find the nearest non-empty cell above
                    for (int searchRow = row - 1; searchRow >= 0; searchRow--)
                    {
                        if (Cells[searchRow, col].GetItem() != null)
                        {
                            FallCommand fallCommand = new FallCommand(Cells[searchRow, col].GetItem().transform, Cells[row, col].transform, 5.0f);
             
                            Game.CommandInvoker.AddCommand(fallCommand);
                            Cells[searchRow, col].GetItem().transform.SetParent(Cells[row, col].transform);
                            break;
                        }
                    }
                }
            }
        }
    }

    public IEnumerator SpawnRecycledItems(List<Item> matchedItems)
    {
        bool hasScheduledSpawn = false;
        for (int row = BoardSize.rows - 1; row >= 0; row--) // Start from the bottom of each column
        {
            for (int col = 0; col < BoardSize.columns; col++)
            {
                if (Cells[row, col].GetItem() == null && matchedItems.Count > 0) // Check if the cell is empty
                {
                    Item recycledItem = matchedItems[matchedItems.Count - 1];
                    matchedItems.RemoveAt(matchedItems.Count - 1);
                    Array colors = System.Enum.GetValues(typeof(CellColor));

                    CellColor randomColor = (CellColor)colors.GetValue(random.Next(colors.Length));
                    recycledItem.SetColor(randomColor);
                    recycledItem.transform.SetParent(Cells[row, col].transform);

                    recycledItem.gameObject.SetActive(true);
                    FallCommand fallCommand = new FallCommand(recycledItem.transform, Cells[row, col].transform, 5.0f);

                    Game.CommandInvoker.AddCommand(fallCommand);
                    hasScheduledSpawn = true;
                }
            }
            if(hasScheduledSpawn)
            {
                yield return new WaitForSeconds(0.2f);
                hasScheduledSpawn = false;
            }
        }
    }

}
