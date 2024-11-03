using System.Collections.Generic;
using Events;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Board Board;

    public static EventSystem CustomEventSystem { get; private set; }  
    public static MatchFinder MatchFinder { get; private set; }
    public static CommandInvoker CommandInvoker { get; private set; }

    void Start()
    {
        CustomEventSystem = new EventSystem();
        MatchFinder = new MatchFinder();

        CommandInvoker = GetComponent<CommandInvoker>();
        UnityEngine.Assertions.Assert.IsNotNull(CommandInvoker, "CommandInvoker is missing.");

        Board = GetComponentInChildren<Board>();
        UnityEngine.Assertions.Assert.IsNotNull(Board, "Board is missing.");

        Board.CreateCells();
        CustomEventSystem.RegisterEvent<OnPlayerTapped>(HandleOnPlayerTapped);
    }

    private void HandleOnPlayerTapped(OnPlayerTapped eventData)
    {
        List<Item> matchedItems = Board.FindMatchedCells(MatchFinder, eventData.cell);
        Board.DeactivateCells(matchedItems);
        Board.DropItemsToEmptyCells();
        StartCoroutine(Board.SpawnRecycledItems(matchedItems));
    }
}
