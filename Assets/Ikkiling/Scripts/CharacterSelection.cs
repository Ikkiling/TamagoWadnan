using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject characterSelectionMenu;

    public GameObject character1;

    public GameObject character2;


    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("CharacterSelected"));

        switch(PlayerPrefs.GetInt("CharacterSelected"))
        {
            case 0:
                characterSelectionMenu.SetActive(true);
                character1.SetActive(false);
                character2.SetActive(false);
                Time.timeScale = 0.0f;
                break;

            case 1:
                characterSelectionMenu.SetActive(false);
                character1.SetActive(true);
                character2.SetActive(false);
                Time.timeScale = 1.0f;
                break;

            case 2:
                characterSelectionMenu.SetActive(false);
                character1.SetActive(false);
                character2.SetActive(true);
                Time.timeScale = 1.0f;
                break;

            default:
                characterSelectionMenu.SetActive(true);
                character1.SetActive(false);
                character2.SetActive(false);
                Time.timeScale = 0.0f;
                break;
        }

    }

    public void Character1Selected()
    {
        characterSelectionMenu.SetActive(false);
        character1.SetActive(true);
        character2.SetActive(false);
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("CharacterSelected", 1);
        PlayerPrefs.Save();
    }

    public void Character2Selected()
    {
        characterSelectionMenu.SetActive(false);
        character1.SetActive(false);
        character2.SetActive(true);
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("CharacterSelected", 2);
        PlayerPrefs.Save();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            characterSelectionMenu.SetActive(true);
            character1.SetActive(false);
            character2.SetActive(false);
            Time.timeScale = 0.0f;
            PlayerPrefs.SetInt("CharacterSelected", 0);
            PlayerPrefs.Save();
        }
    }
}
