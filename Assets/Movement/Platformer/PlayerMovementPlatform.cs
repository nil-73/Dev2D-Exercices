using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementPlatform : MonoBehaviour
{
    /* 
     * Add rigidbody dynamic to player, rigidbody kinematic to the platforms, boxcollider to both
     * Add PlayerInput (InputSystem) to player, set default map to Player, behaviour --> send messages (OnMove...)
     * Set Default Scheme --> mouse & keyboard
    */

    private Rigidbody2D rb;
    private float horizontalDir;

    public float Speed = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.x = horizontalDir * Speed;
        rb.linearVelocity = velocity;
    }

    private void OnMove(InputValue inputValue)
    {
        Vector2 input = inputValue.Get<Vector2>();
        horizontalDir = input.x;
    }
}
