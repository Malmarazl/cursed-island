using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{
    public AudioMixer musicMixer, effectsMixer;

    public float masterVol, effectsVol;

    [Range(-80, 10)]
    public Slider musicSlider, effectSlider;

    void Start()
    {
        musicSlider.minValue = -25;
        musicSlider.maxValue = 10;

        effectSlider.minValue = -25;
        effectSlider.maxValue = 10;

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        effectSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0f);
    }

    public void MusicVolume()
    {
        DataManager.instance.MusicData(musicSlider.value);
        musicMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void EffectsVolume()
    {
        DataManager.instance.EffectsData(effectSlider.value);
        effectsMixer.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("EffectsVolume"));
    }
}
