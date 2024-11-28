using System;
using UnityEngine;


public class EndGame : MonoBehaviour
{
    public static Action<int> CharacterStage;

    public static Action<int> GOHealth;
    public static Action<int> GODirty;
    public static Action<int> GOHunger;
    public static Action<int> GOThirst;
    public static Action<int> GOMood;

    private bool characterHealth;
    private bool characterDirtiness;
    private bool characterHunger;
    private bool characterThirst;
    private bool characterMood;

    public GameObject endPanel;
    public GameObject gameoverPanel;

    public MonoBehaviour[] endScripts;


    private void OnEnable()
    {
        CharacterStage += GetCharacterStage;
        GOHealth += GetCharacterHealth;
        GODirty += GetCharacterDirty;
        GOHunger += GetCharacterHunger;
        GOThirst += GetCharacterThirst;
        GOMood += GetCharacterMood;

    }

    private void OnDisable()
    {
        CharacterStage -= GetCharacterStage;
        GOHealth -= GetCharacterHealth;
        GODirty -= GetCharacterDirty;
        GOHunger -= GetCharacterHunger;
        GOThirst -= GetCharacterThirst;
        GOMood -= GetCharacterMood;

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

    private void Update()
    {
        if (characterHealth || characterDirtiness || characterHunger || characterThirst || characterMood)
        {

            for (int i = 0; i < endScripts.Length; i++)
            {
                endScripts[i].enabled = false;
            }

            if (gameoverPanel != null)
            {
                gameoverPanel.SetActive(true);
            }

            Time.timeScale = 0.0f;

            Debug.Log("Game Over");
        }
    }

    private void GetCharacterHealth(int health)
    {
        characterHealth = (health <= 0) ? true : false;
    }

    private void GetCharacterDirty(int dirty)
    {
        characterDirtiness = (dirty <= 0) ? true : false;
    }

    private void GetCharacterHunger(int hunger)
    {
        characterHunger = (hunger <= 0) ? true : false;
    }

    private void GetCharacterThirst(int thirst)
    {
        characterThirst = (thirst <= 0) ? true : false;
    }

    private void GetCharacterMood(int mood)
    {
        characterMood = (mood <= 0) ? true : false;
    }
}

