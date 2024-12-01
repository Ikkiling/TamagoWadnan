using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject characterSelectionMenu;
    public GameObject characterExpression;

    public Button[] pauseButtons;

    public void Character1Selected()
    {
        characterSelectionMenu.SetActive(false);
        characterExpression.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -100, 0);
        CharacterEvolve.CharacterStage?.Invoke(1);

        for (int i = 0; i < pauseButtons.Length; i++)
        {
            pauseButtons[i].interactable = true;
        }

        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("CharacterSelected", 1);
        PlayerPrefs.SetInt("Square 1", 1);
        PlayerPrefs.Save();
    }

    public void Character2Selected()
    {
        characterSelectionMenu.SetActive(false);
        characterExpression.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -200, 0);
        CharacterEvolve.CharacterStage?.Invoke(4);

        for (int i = 0; i < pauseButtons.Length; i++)
        {
            pauseButtons[i].interactable = true;
        }

        Time.timeScale = 1.0f;
        PlayerPrefs.SetInt("CharacterSelected", 4);
        PlayerPrefs.SetInt("Triangle 1", 1);
        PlayerPrefs.Save();
    }

}
