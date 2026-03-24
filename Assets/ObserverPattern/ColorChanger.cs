using System;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public static event Action<Color> OnChangeColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnChangeColor?.Invoke(collision.GetComponent<SpriteRenderer>().color);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        OnChangeColor?.Invoke(Color.white);
    }
}
