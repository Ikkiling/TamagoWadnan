using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameplayInitialize : MonoBehaviour
{
    public GameObject characterSelectionMenu;
    public GameObject characterExpression;
    public GameObject endPanel;
    public GameObject overPanel;
    public GameObject pausePanel;
    public GameObject optionPanel;

    //set script execution order from this then only character selection.
    //need to modify character selection menu a bit.
    //In Beginning, check character stage, disable or enable character selection menu, then change character image based on stage.


    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("CharacterSelected"));

        endPanel.SetActive(false);
        overPanel.SetActive(false);
        pausePanel.SetActive(false);
        optionPanel.SetActive(false);

        Actions.expIncreament?.Invoke(0);

        switch (PlayerPrefs.GetInt("CharacterSelected"))
        {
            case 0:
                characterSelectionMenu.SetActive(true);
                CharacterEvolve.CharacterStage?.Invoke(0);
                Time.timeScale = 0.0f;
                break;

            case 1:
                characterSelectionMenu.SetActive(false);
                characterExpression.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -100, 0);
                CharacterEvolve.CharacterStage?.Invoke(1);
                Time.timeScale = 1.0f;
                break;

            case 2:
                characterSelectionMenu.SetActive(false);
                characterExpression.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -200, 0);
                CharacterEvolve.CharacterStage?.Invoke(4);
                Time.timeScale = 1.0f;
                break;

            default:
                characterSelectionMenu.SetActive(true);
                CharacterEvolve.CharacterStage?.Invoke(0);
                Time.timeScale = 0.0f;
                break;

        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            characterSelectionMenu.SetActive(true);
            CharacterEvolve.CharacterStage?.Invoke(0);
            Time.timeScale = 0.0f;
            PlayerPrefs.SetInt("CharacterSelected", 0);
            PlayerPrefs.Save();
        }
    }
}
