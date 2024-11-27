using System;
using UnityEngine;


public class EndGame : MonoBehaviour
{
    public static Action<int> CharacterStage;


    public GameObject endPanel;

    public MonoBehaviour[] endScripts;


    private void OnEnable()
    {
        CharacterStage += GetCharacterStage;

    }

    private void OnDisable()
    {
        CharacterStage -= GetCharacterStage;

    }

    private void GetCharacterStage(int characterStage)
    {
        if (characterStage == 3 || characterStage == 6)
        {

            for (int i = 0; i < endScripts.Length; i++)
            {
                endScripts[i].enabled = false;
            }

            if (endPanel != null)
            {
                endPanel.SetActive(true);
            }

            Time.timeScale = 0.0f;

            Debug.Log("End Game");
        }
    }
}

