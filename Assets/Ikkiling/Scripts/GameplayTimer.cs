using TMPro;
using UnityEngine;

public class GameplayTimer : MonoBehaviour
{
    public TMP_Text timerText;

    private float timer = 0.0f;


    void Update()
    {
        timer += Time.deltaTime;
        DisplayTime();

        if(Input.GetKeyDown(KeyCode.R))
        {
            ResetTimer();
        }
    }

    void DisplayTime()
    {
        int minutes = Mathf.FloorToInt(timer / 60.0f);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void ResetTimer()
    {
        timer = 0.0f;
    }
}
