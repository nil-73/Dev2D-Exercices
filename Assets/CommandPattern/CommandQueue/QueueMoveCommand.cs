using UnityEngine;

public class QueueMoveCommand : QueueCommand
{
    private Vector2 direction;

    public QueueMoveCommand(QueueEntity entity, Vector2 direction) : base(entity)
    {
        this.direction = direction;
    }

    public override void Execute()
    {
        localEntity.Move(direction);
    }

    public override void Undo()
    {
        localEntity.Move(-direction);
    }
}