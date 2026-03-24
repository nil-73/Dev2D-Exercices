using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerJetpack : MonoBehaviour
{
    [Header("Jetpack")]
    public float jetpackForce = 12f;
    public int maxFuel = 200;
    public int fuel = 200;
    public int fuelUsePerTick = 1;
    public int fuelRechargePerTick = 3;
    public Slider slider;

    [Header("Ground Detection")]
    public ContactFilter2D filter;
    public float groundCheckDistance = 0.6f;

    private Rigidbody2D rb;
    private bool grounded;
    private bool isHoldingJump;

    public static Action<int> OnChangeFuel;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        slider.maxValue = maxFuel;
        slider.value = fuel;

        filter.useLayerMask = true;
        filter.useTriggers = false;
    }

    void FixedUpdate()
    {
        grounded = IsGrounded();

        // Recharge fuel on ground
        if (grounded)
        {
            if (fuel < maxFuel)
            {
                fuel += fuelRechargePerTick;
                OnChangeFuel?.Invoke(fuel);
                slider.value = fuel;
            }
        }

        // Use jetpack only while holding jump and having fuel
        if (isHoldingJump && fuel > 0)
        {
            if (fuel > 0)
            {
                Vector2 velocity = rb.linearVelocity;
                velocity.y = jetpackForce;
                rb.linearVelocity = velocity;
                fuel -= fuelUsePerTick;
                OnChangeFuel?.Invoke(fuel);
                slider.value = fuel;
            }
        }
        else
        {
            if (rb.linearVelocity.y > 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            }
        }
    }

    public void OnJump()
    {
        Debug.Log("pressed");
        isHoldingJump = true;
    }

    public void OnJumpFinished()
    {
        Debug.Log("released");
        isHoldingJump = false;
    }

    private bool IsGrounded()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.down * 0.5f;
        RaycastHit2D[] hits = new RaycastHit2D[2];

        int count = Physics2D.Raycast(origin, Vector2.down, filter, hits, groundCheckDistance);
        return count > 0;
    }
}