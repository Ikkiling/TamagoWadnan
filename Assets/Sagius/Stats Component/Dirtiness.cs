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
    }
}
