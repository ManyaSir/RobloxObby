using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundControllerVersion3 : MonoBehaviour
{
    public Slider volumeSlider1;
    public Text volumeText1;
    public Slider volumeSlider2;
    public Text volumeText2;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;
    public string SaveKey;
    private float volume;

    private void Start()
    {
        UpdateInfoSound();
    }

    public void SetVolume(int Index)
    {
        if (Index == 1)
        {
            volume = volumeSlider1.value;
            audioSource1.volume = volume;
            audioSource2.volume = volume;
            audioSource3.volume = volume;
            audioSource4.volume = volume;
            volumeText1.text = Mathf.RoundToInt(volume * 100f) + "%";
            PlayerPrefs.SetFloat(SaveKey, volume);
            PlayerPrefs.Save();

        } else if (Index == 2)
        {
            volume = volumeSlider2.value;
            audioSource1.volume = volume;
            audioSource2.volume = volume;
            audioSource3.volume = volume;
            audioSource4.volume = volume;
            volumeText2.text = Mathf.RoundToInt(volume * 100f) + "%";
            PlayerPrefs.SetFloat(SaveKey, volume);
            PlayerPrefs.Save();
        }
        
    }

    public void UpdateInfoSound()
    {
        volumeSlider1.value = PlayerPrefs.GetFloat(SaveKey);
        volumeSlider2.value = PlayerPrefs.GetFloat(SaveKey);
        volumeText1.text = Mathf.RoundToInt(volumeSlider1.value * 100f) + "%";
        volumeText2.text = Mathf.RoundToInt(volumeSlider1.value * 100f) + "%";
    }
    
}
