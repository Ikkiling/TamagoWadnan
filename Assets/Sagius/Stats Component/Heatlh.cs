using UnityEngine;

public class HealthController : StatController
{
    protected override void OnStatAdjusted()
    {
        base.OnStatAdjusted();
        if (level <= 0)
        {
            Debug.Log("Health critical! The player has died.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AdjustStat();
        }
    }

    private void OnEnable()
    {
        Actions.medicineIncreament += HealthIncrease;
    }

    private void OnDisable()
    {
        Actions.medicineIncreament -= HealthIncrease;
    }

    private void HealthIncrease(int medicineGain)
    {
        level += medicineGain;

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

        Debug.Log("medicine gain = " + medicineGain);
        Debug.Log("current health = " + level);
    }
}
