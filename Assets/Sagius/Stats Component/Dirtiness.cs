using UnityEngine;

public class DirtinessController : StatController
{
    protected override void OnStatAdjusted()
    {
        base.OnStatAdjusted();
        if (level >= maxValue)
        {
            Debug.Log("Dirtiness critical! You are extremely dirty.");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AdjustStat();
        }

        changeRate = Random.Range(0, -10);

        if (level > minValue)
        {
            level += changeRate * Time.deltaTime;
        }

        level = Mathf.Clamp(level, minValue, maxValue);

        EmojiManager.GetDirty?.Invoke((int)level);
        EndGame.GODirty?.Invoke((int)level);


        if (slider != null)
        {
            slider.value = level;
        }
    }

    private void OnEnable()
    {
        Actions.bathIncreament += DirtyIncrease;
    }

    private void OnDisable()
    {
        Actions.bathIncreament -= DirtyIncrease;
    }

    private void DirtyIncrease(int bathGain)
    {
        level += bathGain;

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

        Debug.Log("bath gain = " + bathGain);
        Debug.Log("current dirtiness = " + level);
    }
}
