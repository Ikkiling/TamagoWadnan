using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject characterSelectionMenu;

    public GameObject character1;

    public GameObject character2;



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

}
