using System;
using UnityEngine;

public class Actions : MonoBehaviour
{
    public int feedAmount;
    public int feedExp;

    public int drinkAmount;
    public int drinkExp;

    public int bathAmount;
    public int bathExp;

    public int playAmount;
    public int playExp;

    public int medicineAmount;
    public int medicineExp;

    public static Action<int> feedIncreament;
    public static Action<int> drinkIncreament;
    public static Action<int> bathIncreament;
    public static Action<int> playIncreament;
    public static Action<int> medicineIncreament;

    public static Action<int> expIncreament;


    public AudioSource sfxAudioSource;
    public AudioClip[] actionsAudioClips;


    public void Feed()
    {
        feedIncreament?.Invoke(feedAmount);
        expIncreament?.Invoke(feedExp);

        sfxAudioSource.PlayOneShot(actionsAudioClips[0]);
    }

    public void Drink()
    {
        drinkIncreament?.Invoke(drinkAmount);
        expIncreament?.Invoke(drinkExp);

        sfxAudioSource.PlayOneShot(actionsAudioClips[1]);
    }

    public void Bath()
    {
        bathIncreament?.Invoke(bathAmount);
        expIncreament?.Invoke(bathExp);

        sfxAudioSource.PlayOneShot(actionsAudioClips[2]);
    }

    public void Play()
    {
        playIncreament?.Invoke(playAmount);
        expIncreament?.Invoke(playExp);

        sfxAudioSource.PlayOneShot(actionsAudioClips[3]);
    }

    public void Medicine()
    {
        medicineIncreament?.Invoke(medicineAmount);
        expIncreament?.Invoke(medicineExp);

        sfxAudioSource.PlayOneShot(actionsAudioClips[4]);
    }



}
