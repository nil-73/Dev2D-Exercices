using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ICommand
{
    protected Entity localEntity;

    protected Command(Entity entity)
    {
        localEntity = entity;
    }

    public abstract void Execute();
    public abstract void Undo();
}
