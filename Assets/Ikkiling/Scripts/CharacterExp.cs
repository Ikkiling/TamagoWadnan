using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterExp : MonoBehaviour
{
    public int currentExp;
    public int maxExp;

    private bool expReturned;

    public static Action EvolveEvent;

    public Slider experienceBar;

    private void OnEnable()
    {
        Actions.expIncreament += ExpIncrease;
        StatController.expReturn += ExpReturn;
    }

    private void OnDisable()
    {
        Actions.expIncreament -= ExpIncrease;
        StatController.expReturn -= ExpReturn;
    }

    private void ExpIncrease(int expGain)
    {
        currentExp += expGain;

        if(expReturned)
        {
            currentExp -= expGain;
        }

        if (currentExp >= maxExp)
        {
            EvolveEvent?.Invoke();
            currentExp -= maxExp;
        }

        if (experienceBar != null)
        {
            experienceBar.value = currentExp;
        }

        Debug.Log("Exp Gained = " + expGain);
        Debug.Log("current Exp = " + currentExp);
    }

    public void ExpReturn(int value)
    {
        if(value == 0)
        {
            expReturned = false;
        }
        else
        {
            expReturned = true;
        }
    }
}
