using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueInvoker : MonoBehaviour
{
    private static Queue<ICommand> commandQueue;
    private static List<ICommand> commandHistory;
    private static int currentIndex;

    public static bool IsExecuting { get; private set; }

    [SerializeField] private float executionDelay = 0.2f;

    private static QueueInvoker instance;

    private void Awake()
    {
        instance = this;
        commandQueue = new Queue<ICommand>();
        commandHistory = new List<ICommand>();
        currentIndex = 0;
        IsExecuting = false;
    }

    public static void AddCommand(ICommand command)
    {
        if (IsExecuting) return;

        commandQueue.Enqueue(command);

        while (commandHistory.Count > currentIndex)
        {
            commandHistory.RemoveAt(currentIndex);
        }
    }

    public static void ExecuteAll()
    {
        if (instance == null) return;
        if (IsExecuting) return;
        if (commandQueue.Count == 0) return;

        instance.StartCoroutine(instance.ExecuteCommandsCoroutine());
    }

    private IEnumerator ExecuteCommandsCoroutine()
    {
        IsExecuting = true;

        while (commandQueue.Count > 0)
        {
            ICommand command = commandQueue.Dequeue();
            command.Execute();

            commandHistory.Add(command);
            currentIndex++;

            yield return new WaitForSeconds(executionDelay);
        }

        IsExecuting = false;
    }

    public static void Undo()
    {
        if (IsExecuting) return;

        if (currentIndex > 0)
        {
            currentIndex--;
            commandHistory[currentIndex].Undo();
        }
    }

    public static void Redo()
    {
        if (IsExecuting) return;

        if (currentIndex < commandHistory.Count)
        {
            commandHistory[currentIndex].Execute();
            currentIndex++;
        }
    }
}