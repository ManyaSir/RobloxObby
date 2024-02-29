using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsChange : MonoBehaviour
{
    
    [SerializeField] private GameObject Map1;
    [SerializeField] private GameObject Map2;
    [SerializeField] public Collider Changer;
    [SerializeField] private GameObject Player;
    [SerializeField] private Buttons buttons;
    [SerializeField] public GameObject GameMusic;
    [SerializeField] public GameObject HellMusic;

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
            Player.SetActive(true);
            Debug.Log("ChangerPlayer");
        }
    }

    public void ChangerLevels()
    {
        Map1.SetActive(false);
        Map2.SetActive(true);
        GameMusic.SetActive(false);
        HellMusic.SetActive(true);
        PlayerPrefs.SetInt("MapStatus", 2);
        PlayerPrefs.Save();
    }

    public void CheckingMapStatus()
    {
        Debug.Log("" + PlayerPrefs.GetInt("MapStatus"));
        
        if(PlayerPrefs.GetInt("MapStatus") == 2)
        {
            Map1.SetActive(false);
            Map2.SetActive(true);
            Debug.Log("ВЫПОЛНИЛОСЬ НОМЕР 2!");

        } else if (PlayerPrefs.GetInt("MapStatus") == 1)
        {
            Map1.SetActive(true);
            Map2.SetActive(false);
            Debug.Log("ВЫПОЛНИЛОСЬ НОМЕР 1!");
        } else if (PlayerPrefs.GetInt("MapStatus") == 3)
        {
            PlayerPrefs.SetInt("MapStatus", 1);
            PlayerPrefs.Save();
            Debug.Log("ВЫПОЛНИЛОСЬ НОМЕР 3!");
            buttons.NewGame();
        }
    }
}
