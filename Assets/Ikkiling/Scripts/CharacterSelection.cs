using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    public GameObject characterSelectionMenu;


    public void Character1Selected()
    {
        characterSelectionMenu.SetActive(false);
        CharacterEvolve.CharacterStage?.Invoke(1);
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("CharacterSelected", 1);
        PlayerPrefs.SetInt("Square 1", 1);
        PlayerPrefs.Save();
    }

    public void Character2Selected()
    {
        characterSelectionMenu.SetActive(false);
        CharacterEvolve.CharacterStage?.Invoke(4);
        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("CharacterSelected", 4);
        PlayerPrefs.SetInt("Triangle 1", 1);
        PlayerPrefs.Save();
    }

}
