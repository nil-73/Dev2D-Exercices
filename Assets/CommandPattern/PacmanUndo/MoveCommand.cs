using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Vector2 direction;

    public MoveCommand(Entity entity, Vector2 direction) : base(entity)
    {
        this.direction = direction;
    }

    public override void Execute()
    {
        localEntity.transform.Translate(direction);
    }

    public override void Undo()
    {
        localEntity.transform.Translate(-direction);
    }
}
