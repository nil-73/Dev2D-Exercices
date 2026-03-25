using UnityEngine;

public class CreateOrbCommand : ICommand
{
    private Color color;
    private GameObject prefab;
    private Vector2 position;

    public CreateOrbCommand(GameObject prefab, Vector2 position, Color color)
    {
        this.color = color;
        this.prefab = prefab;
        this.position = position;
    }

    public void Execute()
    {
        OrbSpawner.AddOrb(prefab, position, color);
    }

    public void Undo()
    {
        OrbSpawner.RemoveOrb(prefab, position, color);
    }
}
