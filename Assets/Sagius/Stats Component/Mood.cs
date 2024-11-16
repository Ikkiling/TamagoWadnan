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
}
