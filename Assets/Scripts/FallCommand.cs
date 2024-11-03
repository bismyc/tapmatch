using UnityEngine;

public class FallCommand : ICommand
{
    private Transform objectTransform;
    private Transform target;
    private float fallSpeed;

    public bool IsComplete { get; private set; } = false;

    public FallCommand(Transform objectTransform, Transform target, float fallSpeed)
    {
        this.objectTransform = objectTransform;
        this.target = target;
        this.fallSpeed = fallSpeed;
        objectTransform.position = new Vector2(target.position.x, objectTransform.position.y);
    }

    public void Execute()
    {
        if (IsComplete) return;
      
        objectTransform.position = Vector2.MoveTowards(objectTransform.position, target.position, fallSpeed * Time.deltaTime);

        if (objectTransform.position == target.position)
        {          
            IsComplete = true;
        }
    }
}
