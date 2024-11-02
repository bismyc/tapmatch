using UnityEngine;

public class InputListener : MonoBehaviour
{
    private Cell Cell;
    private void Start()
    {
        Cell = GetComponentInChildren<Cell>();
        UnityEngine.Assertions.Assert.IsNotNull(Cell, "Cell is missing.");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    
                    Game.CustomEventSystem.SendEvent<Events.OnPlayerTapped>(new Events.OnPlayerTapped { cell = Cell });
                }
            }
        }
    }
}
