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
}
