using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button pauseButton;

    public void OpenPauseButton()
    {
        pauseMenu.SetActive(true);
        pauseButton.interactable = false;
        Time.timeScale = 0.0f;
    }

    public void ContinueButton()
    {
        pauseMenu.SetActive(false);
        pauseButton.interactable = true;
        Time.timeScale = 1.0f;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }



}
