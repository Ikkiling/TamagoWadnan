using UnityEngine;

public class MoodController : StatController
{
    protected override void OnStatAdjusted()
    {
        base.OnStatAdjusted();
        if (level <= 20)
        {
            Debug.Log("Mood is very low! The character feels unhappy.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            AdjustStat();
        }
    }

    private void OnEnable()
    {
        Actions.playIncreament += MoodIncrease;
    }

    private void OnDisable()
    {
        Actions.playIncreament -= MoodIncrease;
    }

    private void MoodIncrease(int playGain)
    {
        level += playGain;

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

        Debug.Log("play gain = " + playGain);
        Debug.Log("current mood = " + level);
    }
}
