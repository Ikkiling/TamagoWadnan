using System;
using UnityEngine;
using UnityEngine.UI;

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

    private void Update()
    {
        if (characterHealth)
        {
            EnableCharacterEmoji(0);
        }
        else
        {
            DisableCharacterEmoji(0);
        }


        if (characterDirtiness)
        {
            EnableCharacterEmoji(1);
        }
        else
        {
            DisableCharacterEmoji(1);
        }


        if (characterHunger)
        {
            EnableCharacterEmoji(2);
        }
        else
        {
            DisableCharacterEmoji(2);
        }


        if (characterThirst)
        {
            EnableCharacterEmoji(3);
        }
        else
        {
            DisableCharacterEmoji(3);
        }


        if (characterMood)
        {
            EnableCharacterEmoji(4);
        }
        else
        {
            DisableCharacterEmoji(4);
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
        characterHealth = (health < 50) ? true : false;
    }

    private void GetCharacterDirty(int dirty)
    {
        characterDirtiness = (dirty < 50) ? true : false;
    }

    private void GetCharacterHunger(int hunger)
    {
        characterHunger = (hunger < 50) ? true : false;
    }

    private void GetCharacterThirst(int thirst)
    {
        characterThirst = (thirst < 50) ? true : false;
    }

    private void GetCharacterMood(int mood)
    {
        characterMood = (mood < 50) ? true : false;
    }
}
