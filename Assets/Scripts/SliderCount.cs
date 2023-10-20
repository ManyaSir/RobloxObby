using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderCount : MonoBehaviour
{
    [SerializeField] private string SaveKey;
    private Slider slider;
    

    void Start()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if(Assets.N.Fridman.SoundVolumeController.Scripts.Sound.IsChanged == true)
        {
            slider.value = PlayerPrefs.GetFloat(SaveKey);
            
        }
    }
}
