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
    }
}
