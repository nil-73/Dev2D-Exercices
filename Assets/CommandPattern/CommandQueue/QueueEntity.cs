using UnityEngine;

public class QueueEntity : MonoBehaviour
{
    [SerializeField] private float stepSize = 1f;

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * stepSize);
    }
}