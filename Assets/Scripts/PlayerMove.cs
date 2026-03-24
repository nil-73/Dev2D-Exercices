using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 5.0f;

    Rigidbody2D rb;
    private float horizontalDir; // Horizontal move direction value [-1, 1]
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = horizontalDir * Speed;
        rb.linearVelocity = velocity;
    }
    void OnMove(InputValue value)
    {
        // Read value from control, the type depends on what
        // type of controls the action is bound to
        var inputVal = value.Get<Vector2>();
        horizontalDir = inputVal.x;
    }
}
