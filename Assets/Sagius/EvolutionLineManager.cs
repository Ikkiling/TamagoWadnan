using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EvolutionLineManager : MonoBehaviour
{
    [Header("Evolution Line 1")]
    public Image[] evolutionLine1;     // UI Images for evolution line 1
    public Sprite[] evolutionSprites1; // Sprites for each evolution stage in line 1
    public string[] evolutionKeys1;    // PlayerPref keys for line 1

    [Header("Evolution Line 2")]
    public Image[] evolutionLine2;     // UI Images for evolution line 2
    public Sprite[] evolutionSprites2; // Sprites for each evolution stage in line 2
    public string[] evolutionKeys2;    // PlayerPref keys for line 2

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to scene loaded event
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Unsubscribe to avoid memory leaks
    }

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject); // Keeps the UI alive across scenes
    }

    private void Start()
    {
        // Example: Unlocking certain evolution stages (you can remove or customize this)
        //PlayerPrefs.SetInt("Square 1", 1);
        //PlayerPrefs.SetInt("Square 3", 1);
        //PlayerPrefs.SetInt("Triangle 3", 1);
        //PlayerPrefs.SetInt("Triangle 2", 0);
        //PlayerPrefs.Save();

        // Call the function to update evolution lines on start
        UpdateEvolutionLines();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateEvolutionLines(); // Update evolution lines when a new scene is loaded
    }

    private void UpdateEvolutionLines()
    {
        UpdateEvolutionLine(evolutionLine1, evolutionSprites1, evolutionKeys1);
        UpdateEvolutionLine(evolutionLine2, evolutionSprites2, evolutionKeys2);
    }

    private void UpdateEvolutionLine(Image[] lineImages, Sprite[] lineSprites, string[] lineKeys)
    {
        for (int i = 0; i < lineKeys.Length; i++)
        {
            if (PlayerPrefs.GetInt(lineKeys[i], 0) == 1) // Check if form is unlocked
            {
                lineImages[i].sprite = lineSprites[i];    // Update sprite
                lineImages[i].color = Color.white;        // Fully visible, white image
            }
            else
            {
                lineImages[i].sprite = lineSprites[i];    // Keep same sprite for consistency
                lineImages[i].color = Color.black;        // Fully black for locked forms
            }
        }
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
