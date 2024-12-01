using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class CharacterEvolve : MonoBehaviour
{
    public static Action<int> CharacterStage;
    public static Action<int> CharacterMood;

    public int currentStage;

    private bool characterMood;

    public TMP_Text stageText;

    public Image evolveImage;
    public Sprite[] evolveSprite;

    public AudioSource sfxAudioSource;
    public AudioClip evolveAudioClip;


    private void OnEnable()
    {
        CharacterExp.EvolveEvent += Evolve;
        CharacterStage += SetCharacterStage;
        CharacterMood += GetCharacterMood;
    }

    private void OnDisable()
    {
        CharacterExp.EvolveEvent -= Evolve;
        CharacterStage -= SetCharacterStage;
        CharacterMood -= GetCharacterMood;
    }

    private void Start()
    {
        evolveImage.enabled = false;

        if (stageText != null)
        {
            if (currentStage > 3)
            {
                stageText.text = "Stage " + (currentStage - 3).ToString();
            }
            else
            {
                stageText.text = "Stage " + currentStage.ToString();
            }

        }
    }

    private void Evolve()
    {
        sfxAudioSource.PlayOneShot(evolveAudioClip);

        StartCoroutine(EvolveAnimation());

        CharacterMutation();

        CharacterSpriteController.CharacterSprite?.Invoke(currentStage);
        EndGame.CharacterStage?.Invoke(currentStage);
        //PlayerPrefs.SetInt("CharacterStage", currentStage);

        SetProgressionPrefs();

        if (stageText != null )
        {
            if(currentStage > 3)
            {
                stageText.text = "Stage " + (currentStage - 3).ToString();
            }
            else
            {
                stageText.text = "Stage " + currentStage.ToString();
            }
        }

        Debug.Log("stage = " + currentStage);
    }    

    IEnumerator EvolveAnimation()
    {
        evolveImage.enabled = true;
        evolveImage.sprite = evolveSprite[0];

        yield return new WaitForSeconds(0.1f);

        evolveImage.sprite = evolveSprite[2];

        yield return new WaitForSeconds(0.1f);

        evolveImage.sprite = evolveSprite[3];

        yield return new WaitForSeconds(0.1f);

        evolveImage.sprite = evolveSprite[4];

        yield return new WaitForSeconds(0.1f);

        evolveImage.enabled = false;
    }
    
    private void CharacterMutation()
    {
        switch (currentStage)
        {
            case 2:
                currentStage = (characterMood) ? currentStage = 3 : currentStage = 6;
                break;
            case 5:
                currentStage = (characterMood) ? currentStage = 6 : currentStage = 3;
                break;
            default:
                currentStage++;
                break;
        }
    }

    private void SetProgressionPrefs()
    {
        switch (currentStage)
        {
            case 2:
                PlayerPrefs.SetInt("Square 2", 1);
                PlayerPrefs.Save();
                break;
            case 3:
                PlayerPrefs.SetInt("Square 3", 1);
                PlayerPrefs.Save();
                break;
            case 5:
                PlayerPrefs.SetInt("Triangle 2", 1);
                PlayerPrefs.Save();
                break;
            case 6:
                PlayerPrefs.SetInt("Triangle 3", 1);
                PlayerPrefs.Save();
                break;
        }
    }

    public void SetCharacterStage(int characterStage)
    {
        currentStage = characterStage;
        CharacterSpriteController.CharacterSprite?.Invoke(currentStage);
        EndGame.CharacterStage?.Invoke(currentStage);
    }

    private void GetCharacterMood(int mood)
    {
        characterMood = (mood > 30) ? true : false;
    }
}
