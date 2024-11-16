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
}
