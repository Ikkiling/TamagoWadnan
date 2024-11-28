using UnityEngine;

public class ThirstController : StatController
{
    protected override void OnStatAdjusted()
    {
        base.OnStatAdjusted();
        if (level <= 0)
        {
            Debug.Log("Thirst critical! You are dehydrated.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AdjustStat();
        }

        changeRate = Random.Range(0, -10);

        if (level > minValue)
        {
            level += changeRate * Time.deltaTime;
        }

        level = Mathf.Clamp(level, minValue, maxValue);

        EmojiManager.GetThirst?.Invoke((int)level);
        EndGame.GOThirst?.Invoke((int)level);

        if (slider != null)
        {
            slider.value = level;
        }
    }

    private void OnEnable()
    {
        Actions.drinkIncreament += ThirstIncrease;
    }

    private void OnDisable()
    {
        Actions.drinkIncreament -= ThirstIncrease;
    }

    private void ThirstIncrease(int drinkGain)
    {
        level += drinkGain;

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

        Debug.Log("drink gain = " + drinkGain);
        Debug.Log("current thirst = " + level);
    }
}
