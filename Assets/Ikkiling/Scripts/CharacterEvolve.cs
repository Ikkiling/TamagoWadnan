using System;
using UnityEngine;
using TMPro;

public class CharacterEvolve : MonoBehaviour
{
    public static Action<int> CharacterStage;

    public int currentStage;

    public TMP_Text stageText;

    private void OnEnable()
    {
        CharacterExp.EvolveEvent += Evolve;
        CharacterStage += SetCharacterStage;
    }

    private void OnDisable()
    {
        CharacterExp.EvolveEvent -= Evolve;
        CharacterStage -= SetCharacterStage;
    }

    private void Start()
    {
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
        currentStage++;
        CharacterSpriteController.CharacterSprite?.Invoke(currentStage);
        EndGame.CharacterStage?.Invoke(currentStage);
        PlayerPrefs.SetInt("CharacterStage", currentStage);
        PlayerPrefs.Save();

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

    public void SetCharacterStage(int characterStage)
    {
        currentStage = characterStage;
        CharacterSpriteController.CharacterSprite?.Invoke(currentStage);
    }
}
