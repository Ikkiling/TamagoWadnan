using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeAdjust : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider BGMSlider;
    public float BGMValue;

    public Slider SFXSlider;
    public float SFXValue;



    void Start()
    {
        BGMValue = PlayerPrefs.GetFloat("BGMVolume", 1);
        BGMSlider.value = BGMValue;
        audioMixer.SetFloat("BGM", Mathf.Log10(BGMValue) * 10);

        SFXValue = PlayerPrefs.GetFloat("SFXVolume", 1);
        SFXSlider.value = SFXValue;
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXValue) * 10);
    }


    void Update()
    {
        BGMValue = BGMSlider.value;
        audioMixer.SetFloat("BGM", Mathf.Log10(BGMValue) * 10);
        PlayerPrefs.SetFloat("BGMVolume", BGMValue);
        PlayerPrefs.Save();

        SFXValue = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXValue) * 10);
        PlayerPrefs.SetFloat("SFXVolume", SFXValue);
        PlayerPrefs.Save();
    }
}
