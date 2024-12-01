using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class EmojiManager : MonoBehaviour
{
    public static Action<int> GetHealth;
    public static Action<int> GetDirty;
    public static Action<int> GetHunger;
    public static Action<int> GetThirst;
    public static Action<int> GetMood;

    public Image ExpressionImage;
    public Sprite[] characterExpression;

    public Image[] EmojiImage;

    private bool characterHealth;
    private bool characterDirtiness;
    private bool characterHunger;
    private bool characterThirst;
    private bool characterMood;


    public AudioSource sfxAudioSource;
    public AudioClip emojiAudioClip;

    private bool healthAudio;
    private bool dirtyAudio;
    private bool hungerAudio;
    private bool thirstAudio;
    private bool moodAudio;


    private void OnEnable()
    {
        GetHealth += GetCharacterHealth;
        GetDirty += GetCharacterDirty;
        GetHunger += GetCharacterHunger;
        GetThirst += GetCharacterThirst;
        GetMood += GetCharacterMood;
    }

    private void OnDisable()
    {
        GetHealth -= GetCharacterHealth;
        GetDirty -= GetCharacterDirty;
        GetHunger -= GetCharacterHunger;
        GetThirst -= GetCharacterThirst;
        GetMood -= GetCharacterMood;
    }

    private void Start()
    {
        healthAudio = false;
        dirtyAudio = false;
        hungerAudio = false;
        thirstAudio = false;
        moodAudio = false;
    }

    private void Update()
    {
        if (characterHealth)
        {
            EnableCharacterEmoji(0);

            if (!healthAudio)
            {
                sfxAudioSource.PlayOneShot(emojiAudioClip);
                healthAudio = true;
            }
        }
        else
        {
            DisableCharacterEmoji(0);

            if (healthAudio)
            {
                healthAudio = false;
            }
        }


        if (characterDirtiness)
        {
            EnableCharacterEmoji(1);

            if (!dirtyAudio)
            {
                sfxAudioSource.PlayOneShot(emojiAudioClip);
                dirtyAudio = true;
            }
        }
        else
        {
            DisableCharacterEmoji(1);

            if (dirtyAudio)
            {
                dirtyAudio = false;
            }
        }


        if (characterHunger)
        {
            EnableCharacterEmoji(2);

            if (!hungerAudio)
            {
                sfxAudioSource.PlayOneShot(emojiAudioClip);
                hungerAudio = true;
            }
        }
        else
        {
            DisableCharacterEmoji(2);

            if (hungerAudio)
            {
                hungerAudio = false;
            }
        }


        if (characterThirst)
        {
            EnableCharacterEmoji(3);

            if (!thirstAudio)
            {
                sfxAudioSource.PlayOneShot(emojiAudioClip);
                thirstAudio = true;
            }
        }
        else
        {
            DisableCharacterEmoji(3);

            if (thirstAudio)
            {
                thirstAudio = false;
            }
        }


        if (characterMood)
        {
            EnableCharacterEmoji(4);

            if (!moodAudio)
            {
                sfxAudioSource.PlayOneShot(emojiAudioClip);
                moodAudio = true;
            }
        }
        else
        {
            DisableCharacterEmoji(4);

            if (moodAudio)
            {
                moodAudio = false;
            }
        }


        if(characterHealth ||  characterDirtiness || characterHunger || characterThirst || characterMood)
        {
            ChangeCharacterExpression(1);
        }
        else
        {
            ChangeCharacterExpression(0);
        }
    }

    private void ChangeCharacterExpression(int expressionNumber)
    {
        ExpressionImage.sprite = characterExpression[expressionNumber];
    }

    private void EnableCharacterEmoji(int emojiNumber)
    {
        EmojiImage[emojiNumber].enabled = true;
    }

    private void DisableCharacterEmoji(int emojiNumber)
    {
        EmojiImage[emojiNumber].enabled = false;
    }

    private void GetCharacterHealth(int health)
    {
        characterHealth = (health < 70) ? true : false;
    }

    private void GetCharacterDirty(int dirty)
    {
        characterDirtiness = (dirty < 70) ? true : false;
    }

    private void GetCharacterHunger(int hunger)
    {
        characterHunger = (hunger < 70) ? true : false;
    }

    private void GetCharacterThirst(int thirst)
    {
        characterThirst = (thirst < 70) ? true : false;
    }

    private void GetCharacterMood(int mood)
    {
        characterMood = (mood < 70) ? true : false;
    }
}
