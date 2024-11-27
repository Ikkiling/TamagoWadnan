using System;
using UnityEngine;
using UnityEngine.UI;

public class EmojiManager : MonoBehaviour
{
    public static Action<int> CharacterExpression;
    public static Action<int> CharacterEmoji;

    public Sprite[] characterExpression;
    public Sprite[] characterEmoji;

    public Image ExpressionImage;
    public Image EmojiImage;

    private void OnEnable()
    {
        CharacterExpression += ChangeCharacterExpression;
        CharacterEmoji += ChangeCharacterEmoji;
    }

    private void OnDisable()
    {
        CharacterExpression -= ChangeCharacterExpression;
        CharacterEmoji -= ChangeCharacterEmoji;
    }

    private void ChangeCharacterExpression(int characterExpressionNumber)
    {
        ExpressionImage.sprite = characterExpression[characterExpressionNumber];
    }

    private void ChangeCharacterEmoji(int characterEmojiNumber)
    {
        EmojiImage.sprite = characterEmoji[characterEmojiNumber];
    }
}
