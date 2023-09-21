using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Customisation : MonoBehaviour
{
    public GameObject Accessory;
    public GameObject Current_Accessory_link;
    

    public void Customisations()
    {
        Accessory.SetActive(true);
        PlayerPrefs.SetString("Current_Accessory_name", this.name);
        PlayerPrefs.Save();
    }
    public void ResetData()
    {
        PlayerPrefs.SetString("Current_Accessory_name", null);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Customisation");
    }

    void Start()
    {
        if(this.CompareTag("MainCustomisation"))
        {
            if(PlayerPrefs.GetString("Current_Accessory_name") != null)
            Current_Accessory_link = transform.Find(PlayerPrefs.GetString("Current_Accessory_name")).gameObject;
            //Current_Accessory_link = transform.Find("Hat").gameObject;
            //Current_Accessory_link.SetActive(true);
            Destroy(Current_Accessory_link);
        }
    }
}
