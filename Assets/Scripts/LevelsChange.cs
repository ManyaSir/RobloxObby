using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsChange : MonoBehaviour
{
    
    [SerializeField] private GameObject Map1;
    [SerializeField] private GameObject Map2;
    [SerializeField] private Collider Changer;

    void Start()
    {
        CheckingMapStatus();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Changer") && other.CompareTag("Player"))
        {
            ChangerLevels();
            Changer.enabled = false;
        }
    }

    public void ChangerLevels()
    {
        Map1.SetActive(false);
        Map2.SetActive(true);
        PlayerPrefs.SetInt("MapStatus", 2);
        PlayerPrefs.Save();
    }

    public void CheckingMapStatus()
    {
        if(PlayerPrefs.GetInt("MapStatus") == 2)
        {
            Map1.SetActive(false);
            Map2.SetActive(true);
        } else if (PlayerPrefs.GetInt("MapStatus") == 1)
        {
            Map1.SetActive(true);
            Map2.SetActive(false);
        }
    }
}
