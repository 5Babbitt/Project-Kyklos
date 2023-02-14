using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderPercentage : MonoBehaviour
{
    [SerializeField] private TMP_Text percentageText;
    [SerializeField] private Slider slider;

    public void OnValueChanged()
    {
        int percentage = (int)(slider.value * 100f);
        percentageText.text = percentage.ToString() + "%";
    }
}
