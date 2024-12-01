using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject creditPanel;

    private void Start()
    {
        optionPanel.SetActive(false);
        creditPanel.SetActive(false);
    }
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void AchievementButton()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
