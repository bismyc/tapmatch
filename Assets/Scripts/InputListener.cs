using UnityEngine;

public class InputListener : MonoBehaviour
{
    private Cell Cell;
    public LayerMask raycastLayerMask;

    private void Start()
    {
        Cell = GetComponentInChildren<Cell>();
        UnityEngine.Assertions.Assert.IsNotNull(Cell, "Cell is missing.");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !Game.CommandInvoker.HasActiveCommands()) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, raycastLayerMask))
            {
                if (hit.transform == transform)
                {
                    Game.CustomEventSystem.SendEvent(new Events.OnPlayerTapped { cell = Cell });
                }
            }
        }
    }
}
