using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    private List<ICommand> activeCommands = new List<ICommand>();

    private void Update()
    {
        // Execute each active command
        for (int i = activeCommands.Count - 1; i >= 0; i--)
        {
            var command = activeCommands[i];
            command.Execute();

            // Remove completed commands from the list
            if (command.IsComplete)
            {
                activeCommands.RemoveAt(i);
            }
        }
    }

    public void AddCommand(FallCommand command)
    {
        activeCommands.Add(command);
    }

    public bool HasActiveCommands()
    {
        return activeCommands.Count > 0;
    }
}
