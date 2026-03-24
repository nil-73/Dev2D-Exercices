using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    public void Init(Vector2 velocity, Color color)
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.linearVelocity = velocity;
        spriteRenderer.color = color;
    }

    public void OnBecameInvisible()
    {
        PoolManager.BackToPool(gameObject);
    }
}
