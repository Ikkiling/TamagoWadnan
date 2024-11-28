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

        changeRate = Random.Range(0, -10);

        if (level > minValue)
        {
            level += changeRate * Time.deltaTime;
        }

        level = Mathf.Clamp(level, minValue, maxValue);

        EmojiManager.GetHealth?.Invoke((int)level);
        EndGame.GOHealth?.Invoke((int)level);

        if (slider != null)
        {
            slider.value = level;
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
