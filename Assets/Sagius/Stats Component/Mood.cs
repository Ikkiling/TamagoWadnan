using UnityEngine;
using UnityEngine.UI;

public class Mood : MonoBehaviour
{
    public float moodLevel = 100f; // Max mood
    [Range(-100, 100)] public float moodChanges = 10f;
    public Slider moodSlider;
    private void Start()
    {
        // Initialize the mood slider if it’s set in the Inspector
        if (moodSlider != null)
        {
            moodSlider.minValue = 0;
            moodSlider.maxValue = 100;
            moodSlider.value = moodLevel;
        }
    }

    public void AdjustMood()
    {
        moodLevel += moodChanges;
        moodLevel = Mathf.Clamp(moodLevel, 0, 100); // Keep mood within 0-100 range

        // Update the UI slider if it’s set
        if (moodSlider != null)
        {
            moodSlider.value = moodLevel;
            Debug.Log("Slider adjusted");
        }
    }

    private void OnValidate()
    {
        // Update slider in real-time in the editor when moodLevel changes
        if (moodSlider != null)
        {
            moodSlider.value = moodLevel;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AdjustMood();


        }
    }
}
