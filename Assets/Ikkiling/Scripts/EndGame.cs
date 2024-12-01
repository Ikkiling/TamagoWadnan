using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    private int currentCharacterStage;

    public Sprite[] endcharacterSprite;
    public GameObject endPanel;
    public Image endCharacterImage;
    public GameObject endCharacterExpression;

    public Sprite[] overcharacterSprite;
    public GameObject overPanel;
    public Image overCharacterImage;
    public GameObject overCharacterExpression;

    public MonoBehaviour[] endScripts;


    public AudioSource sfxAudioSource;
    public AudioClip endAudioClip;
    public AudioClip overAudioClip;

    private bool endAudio;
    private bool overAudio;

    public Button[] pauseButtons;


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

    private void Start()
    {
        endAudio = false;
        overAudio = false;
    }

    private void Update()
    {
        if (characterHealth || characterDirtiness || characterHunger || characterThirst || characterMood)
        {

            for (int i = 0; i < endScripts.Length; i++)
            {
                endScripts[i].enabled = false;
            }

            if (overPanel != null)
            {
                overPanel.SetActive(true);
            }

            if(!overAudio)
            {
                sfxAudioSource.PlayOneShot(overAudioClip);
                overAudio = true;
            }

            for (int i = 0; i < pauseButtons.Length; i++)
            {
                pauseButtons[i].interactable = false;
            }


            PlayerPrefs.SetInt("CharacterSelected", 0);

            Time.timeScale = 0.0f;

            Debug.Log("Game Over");
        }

        PanelsUpdate();
    }

    private void PanelsUpdate()
    {
        if (endPanel != null && endPanel.activeSelf)
        {
            switch (currentCharacterStage)
            {
                case 3:
                    endCharacterImage.sprite = endcharacterSprite[0];
                    endCharacterExpression.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -100, 0);
                    break;
                case 6:
                    endCharacterImage.sprite = endcharacterSprite[1];
                    endCharacterExpression.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -100, 0);
                    break;
            }
        }

        if (overPanel != null && overPanel.activeSelf)
        {
            switch (currentCharacterStage)
            {
                case 1:
                    overCharacterImage.sprite = overcharacterSprite[0];
                    overCharacterExpression.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                    break;
                case 2:
                    overCharacterImage.sprite = overcharacterSprite[1];
                    overCharacterExpression.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
                    break;
                case 4:
                    overCharacterImage.sprite = overcharacterSprite[2];
                    overCharacterExpression.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -80, 0);
                    break;
                case 5:
                    overCharacterImage.sprite = overcharacterSprite[3];
                    overCharacterExpression.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -50, 0);
                    break;
            }
        }
    }

    private void GetCharacterStage(int characterStage)
    {
        currentCharacterStage = characterStage;

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

            if (!endAudio)
            {
                sfxAudioSource.PlayOneShot(endAudioClip);
                endAudio = true;
            }

            for (int i = 0; i < pauseButtons.Length; i++)
            {
                pauseButtons[i].interactable = false;
            }

            PlayerPrefs.SetInt("CharacterSelected", 0);

            Time.timeScale = 0.0f;

            Debug.Log("End Game");
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

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    
    public void ReplayButton()
    {
        SceneManager.LoadScene(1);
    }
}

