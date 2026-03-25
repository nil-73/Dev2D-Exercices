using UnityEngine;
using Random = UnityEngine.Random;

public class ClickRegister : MonoBehaviour      // InputHandler
{
    public GameObject StarPrefab;
    public GameObject MoonPrefab;

    void Update()
    {
        // Create required commands on inputs
        if (Input.GetMouseButtonDown(0)) CreateOrb(StarPrefab);
        if (Input.GetMouseButtonDown(1)) CreateOrb(MoonPrefab);
        if (Input.GetKeyDown(KeyCode.R)) RotateCamera();

        // Call Invoker to execute required actions
        if (Input.GetKeyDown(KeyCode.Return)) Invoker.ExecuteAll();

        if (Input.GetKey(KeyCode.LeftControl) && 
            Input.GetKeyDown(KeyCode.Z)) Invoker.Undo();

        if (Input.GetKey(KeyCode.LeftControl) && 
            Input.GetKeyDown(KeyCode.Y)) Invoker.Redo();
    }

    public static void CreateOrb(GameObject prefab)
    {
        var clickPosition = GetClickPosition();
        var color = GetRandomColor();
      
        if (clickPosition != null)
        {
            var command = new CreateOrbCommand(prefab, (Vector2)clickPosition, color);
            Invoker.AddCommand(command);
        }
    }

    private void RotateCamera()
    {
        var command = new RotateCameraCommand();
        Invoker.AddCommand(command);
    }

    private static Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value, 1);
    }

    private static Vector2? GetClickPosition()
    {
        // Convert mouse coordinates to world coordinates
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (hit.collider != null)
        {
            return hit.point;
        }

        return null;
    }
}
