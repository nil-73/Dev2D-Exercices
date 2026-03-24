using UnityEngine;

public class ObserverPattern : MonoBehaviour
{
    [SerializeField] SpriteRenderer circleRenderer;

    private void OnEnable()
    {
        ColorChanger.OnChangeColor += ChangeColorOfCircle;
    }

    private void OnDisable()
    {
        ColorChanger.OnChangeColor -= ChangeColorOfCircle;
    }

    private void ChangeColorOfCircle(Color color)
    {
        circleRenderer.color = color;
    }
}
