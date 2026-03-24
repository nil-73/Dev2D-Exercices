using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    [SerializeField] private float speed = 5.0f;

    private Transform currentTarget;

    private void Start()
    {
        transform.position = pointA.position;
        currentTarget = pointB;
    }

    private void Update()
    {
        Vector3 direction = (currentTarget.position - transform.position).normalized;
        transform.position += (speed * Time.deltaTime * direction);

        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            if (currentTarget == pointA) currentTarget = pointB;
            else currentTarget = pointA;
        }
    }

    private void OnLeftClick()
    {
        UpdatePoint(pointA);
    }

    private void OnRightClick()
    {
        UpdatePoint(pointB);
    }

    private void UpdatePoint(Transform point)
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = -10;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;

        point.position = worldPos;
    }
}
