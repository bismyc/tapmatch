using System.Collections.Generic;

public class MatchFinder
{
    // Define movement directions for up, down, left, and right
    private static readonly int[] dRow = { -1, 1, 0, 0 };
    private static readonly int[] dCol = { 0, 0, -1, 1 };

    public IReadOnlyList<Cell> BreadthFirstSearch(Cell[,] board, Cell startCell)
    {
        int rows = board.GetLength(0);
        int cols = board.GetLength(1);
        Board.CellColor targetColor = startCell.MyColor;
        List<Cell> connectedCells = new List<Cell>();

        // Create a set to keep track of visited cells
        HashSet<Cell> visited = new HashSet<Cell>();
        Queue<Cell> queue = new Queue<Cell>();

        // Enqueue the starting cell and mark it as visited
        queue.Enqueue(startCell);
        visited.Add(startCell);

        while (queue.Count > 0)
        {
            Cell currentCell = queue.Dequeue();
            connectedCells.Add(currentCell);

            // Check each of the four neighbors
            for (int i = 0; i < 4; i++)
            {
                int newRow = currentCell.Index.row + dRow[i];
                int newCol = currentCell.Index.col + dCol[i];

                // Ensure the neighbor is within bounds
                if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols)
                {
                    Cell neighborCell = board[newRow, newCol];

                    // Only add neighbors that match the color and haven't been visited
                    if (!visited.Contains(neighborCell) && neighborCell.MyColor == targetColor)
                    {
                        queue.Enqueue(neighborCell);
                        visited.Add(neighborCell); // Mark as visited
                    }
                }
            }
        }

        return connectedCells.AsReadOnly();
    }

}
