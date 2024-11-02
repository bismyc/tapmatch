using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Board Board;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Board = GetComponentInChildren<Board>();
        UnityEngine.Assertions.Assert.IsNotNull(Board, "Board is missing.");
        Board.CreateCells();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
