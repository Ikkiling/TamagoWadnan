using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSpriteController : MonoBehaviour
{

    public static Action<int> CharacterSprite;

    public Sprite[] characterSprite;

    public Image characterImage;

    private void OnEnable()
    {
        CharacterSprite += ChangeCharacterSprite;
    }

    private void OnDisable()
    {
        CharacterSprite -= ChangeCharacterSprite;
    }

    private void ChangeCharacterSprite(int characterSpriteNumber)
    {
        characterImage.sprite = characterSprite[characterSpriteNumber];
    }
}
