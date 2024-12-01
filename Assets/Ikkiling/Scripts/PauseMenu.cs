using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button[] pauseButtons;

    public void OpenPauseButton()
    {
        pauseMenu.SetActive(true);

        for (int i = 0; i < pauseButtons.Length; i++)
        {
            pauseButtons[i].interactable = false;
        }
   
        Time.timeScale = 0.0f;
    }

    public void ContinueButton()
    {
        pauseMenu.SetActive(false);

        for (int i = 0; i < pauseButtons.Length; i++)
        {
            pauseButtons[i].interactable = true;
        }

        Time.timeScale = 1.0f;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }



}
