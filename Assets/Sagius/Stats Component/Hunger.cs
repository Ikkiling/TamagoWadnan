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

        changeRate = Random.Range(0, -10);

        if (level > minValue)
        {
            level += changeRate * Time.deltaTime;
        }

        level = Mathf.Clamp(level, minValue, maxValue);

        EmojiManager.GetHunger?.Invoke((int)level);
        EndGame.GOHunger?.Invoke((int)level);

        if (slider != null)
        {
            slider.value = level;
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
