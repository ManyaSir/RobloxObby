using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom : MonoBehaviour
{
    
    public GameObject Accessory;
    [SerializeField] public int Accessory_Index;
    
    void Start()
    {
        
    }

    public void Customing()
    {
        GameObject[] accessories = GameObject.FindGameObjectsWithTag("Accessory");
        foreach(GameObject accessory in accessories) 
        {
            accessory.SetActive(false);
        }
        Accessory.SetActive(true);
    }

    public void Buy10()
    {
        if(PlayerPrefs.GetInt("Money") >= 10)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 10);
            PlayerPrefs.Save();
            Destroy(this.gameObject);
        }
    }

    public void Buy25()
    {
        if(PlayerPrefs.GetInt("Money") >= 25)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 25);
            PlayerPrefs.Save();
            Destroy(this.gameObject);

        }
    }

    public void Buy50()
    {
        if(PlayerPrefs.GetInt("Money") >= 50)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 50);
            PlayerPrefs.Save();
            Destroy(this.gameObject);

        }
    }
    
}
