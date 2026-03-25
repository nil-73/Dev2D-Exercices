using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public bool ExecuteImmediate;

    private static Queue<ICommand> CommandQueue;
    private static List<ICommand> CommandHistory;
    private static int currentIndex;

    void Awake()
    {
        CommandQueue = new Queue<ICommand>();
        CommandHistory = new List<ICommand>();
    }

    void Update()
    {
       if (ExecuteImmediate) ExecuteAll();
    }

    public static void ExecuteAll()
    {
        while (CommandQueue.Count > 0)
        {
            ICommand command = CommandQueue.Dequeue();
            command.Execute();

            CommandHistory.Add(command);
            currentIndex++;
        }
    }

    public static void AddCommand(ICommand command)
    {
        CommandQueue.Enqueue(command);

        while (CommandHistory.Count > currentIndex)
        {
            CommandHistory.RemoveAt(currentIndex);
        }
    }

    public static void Undo()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            CommandHistory[currentIndex].Undo();
        }
    }

    public static void Redo()
    {
        if (currentIndex < CommandHistory.Count)
        {
            CommandHistory[currentIndex].Execute();
            currentIndex++;
        }
    }
}
