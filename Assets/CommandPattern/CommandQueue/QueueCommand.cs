public abstract class QueueCommand : ICommand
{
    protected QueueEntity localEntity;

    protected QueueCommand(QueueEntity entity)
    {
        localEntity = entity;
    }

    public abstract void Execute();
    public abstract void Undo();
}