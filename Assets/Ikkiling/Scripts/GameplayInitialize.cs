using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameplayInitialize : MonoBehaviour
{
    public GameObject characterSelectionMenu;

    public GameObject character1;

    public GameObject character2;

    //set script execution order from this then only character selection.
    //need to modify character selection menu a bit.
    //In Beginning, check character stage, disable or enable character selection menu, then change character image based on stage.


    void Start()
    {
        Debug.Log(PlayerPrefs.GetInt("CharacterSelected"));

        if (characterSelectionMenu.activeSelf)
        {
            switch (PlayerPrefs.GetInt("CharacterSelected"))
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
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
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
