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

        changeRate = Random.Range(0, -10);

        if (level > minValue)
        {
            level += changeRate * Time.deltaTime;
        }

        level = Mathf.Clamp(level, minValue, maxValue);

        CharacterEvolve.CharacterMood?.Invoke((int)level);
        EmojiManager.GetMood?.Invoke((int)level);
        EndGame.GOMood?.Invoke((int)level);

        if (slider != null)
        {
            slider.value = level;
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
