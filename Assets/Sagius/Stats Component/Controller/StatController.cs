using UnityEngine;
using UnityEngine.UI;

public class StatController : MonoBehaviour
{
    [Header("Stat Settings")]
    public float level = 100f; // Current level (e.g., hunger, thirst, dirtiness)
    [Range(-100, 100)] public float changeRate = 0f; // Change rate
    public Slider slider;

    public float minValue = 0f;
    public float maxValue = 100f;

    private void Start()
    {
        InitializeSlider();
    }

    private void InitializeSlider()
    {
        if (slider != null)
        {
            slider.minValue = minValue;
            slider.maxValue = maxValue;
            slider.value = level;
        }
    }

    public void AdjustStat()
    {
        level += changeRate;
        level = Mathf.Clamp(level, minValue, maxValue);

        if (slider != null)
        {
            slider.value = level;
        }

        OnStatAdjusted();
    }

    protected virtual void OnStatAdjusted()
    {
        // Override this in child scripts for custom behavior
        Debug.Log($"{gameObject.name} stat adjusted: {level}");
    }

    private void OnValidate()
    {
        if (slider != null)
        {
            slider.value = level;
        }
    }
}
