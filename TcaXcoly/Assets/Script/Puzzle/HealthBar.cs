using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHeath()
    {
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}