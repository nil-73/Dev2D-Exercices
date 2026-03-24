using UnityEngine;
using UnityEngine.UI;

public class FuelTxt : MonoBehaviour
{
    private Text label;

    private void Awake()
    {
        label = GetComponent<Text>();
    }

    private void OnEnable()
    {
        PlayerJetpack.OnChangeFuel += UpdateScoreText;
    }

    private void OnDisable()
    {
        PlayerJetpack.OnChangeFuel -= UpdateScoreText;
    }

    private void UpdateScoreText(int fuel)
    {
        label.text =  "FUEL: " + fuel.ToString();
    }
}
