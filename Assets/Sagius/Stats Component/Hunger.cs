using UnityEngine;

public class HungerController : StatController
{
    protected override void OnStatAdjusted()
    {
        base.OnStatAdjusted();
        if (level <= 0)
        {
            Debug.Log("Hunger critical! You are starving.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AdjustStat();
        }
    }

    private void OnEnable()
    {
        Actions.feedIncreament += HungerIncrease;
    }

    private void OnDisable()
    {
        Actions.feedIncreament -= HungerIncrease;
    }

    private void HungerIncrease(int feedGain)
    {
        level += feedGain;

        if (level > maxValue)
        {
            expReturn?.Invoke(1);
        }
        else
        {
            expReturn?.Invoke(0);
        }

        level = Mathf.Clamp(level, minValue, maxValue);

        if (slider != null)
        {
            slider.value = level;
        }

        Debug.Log("feed gain = " + feedGain);
        Debug.Log("current hunger = " + level);
    }
}
