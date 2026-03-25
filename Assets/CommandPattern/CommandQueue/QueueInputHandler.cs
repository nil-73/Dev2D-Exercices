using UnityEngine;
using UnityEngine.InputSystem;

public class QueueInputHandler : MonoBehaviour
{
    [SerializeField] private QueueEntity player;
    private void OnMove(InputValue value)
    {
        if (QueueInvoker.IsExecuting) return;

        var direction = value.Get<Vector2>();
        
        if (direction != Vector2.zero)
        {
            var moveCommand = new QueueMoveCommand(player, direction);
            QueueInvoker.AddCommand(moveCommand);
        }
    }

    private void OnNextPlayer()
    {
        QueueInvoker.ExecuteAll();
    }

    private void OnUndo()
    {
        QueueInvoker.Undo();
    }

    private void OnRedo()
    {
        QueueInvoker.Redo();
    }
}
