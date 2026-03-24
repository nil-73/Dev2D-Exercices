using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private float horizontalDir;
    private float verticalDir;

    public float Speed = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;

        velocity.x = horizontalDir * Speed;
        velocity.y = verticalDir * Speed;
        
        rb.linearVelocity = velocity;
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 input = inputValue.Get<Vector2>();

        horizontalDir = input.x;
        verticalDir = input.y;
    }
}
