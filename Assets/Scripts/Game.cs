using System;
using System.Collections.Generic;
using Events;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Board Board;

    public static EventSystem CustomEventSystem { get; private set; }  
    public static MatchFinder MatchFinder { get; private set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CustomEventSystem = new EventSystem();
        MatchFinder = new MatchFinder();
        Board = GetComponentInChildren<Board>();
        UnityEngine.Assertions.Assert.IsNotNull(Board, "Board is missing.");
        Board.CreateCells();
        CustomEventSystem.RegisterEvent<Events.OnPlayerTapped>(HandleOnPlayerTapped);
    }

    private void OnDestroy()
    {
        CustomEventSystem.UnRegisterEvent<Events.OnPlayerTapped>(HandleOnPlayerTapped);
    }

    private void HandleOnPlayerTapped(OnPlayerTapped eventData)
    {
        IReadOnlyList<Cell> connectedCells = MatchFinder.BreadthFirstSearch(Board.Cells, eventData.cell);
        foreach (Cell cell in connectedCells)
        {
            Debug.Log(cell.transform.name); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
