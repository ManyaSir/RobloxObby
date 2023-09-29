using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom : MonoBehaviour
{
    
    public GameObject Accessory;
    [SerializeField] public int Accessory_Index;
    public GameManager gamemanager;
    
    void Start()
    {
        if(this.CompareTag("Custom_Controller"))
        
        {    for(int i = 0; i < 4; i++)
            {
                if(GameManager.Cost_Panels_Active_Page_1[i] == 0)
                {
                    GameObject Panel = GameObject.Find("Cost" + i);
                    if(Panel != null)
                    {
                        Panel.SetActive(true);
                    }
                } else if (GameManager.Cost_Panels_Active_Page_1[i] == 1)
                {
                    GameObject Panel = GameObject.Find("Cost" + i);
                    if(Panel != null)
                    {
                        Panel.SetActive(false);
                    }
                }
            }
            for(int i = 0; i < 4; i++)
            {
                if(GameManager.Cost_Panels_Active_Page_2[i] == 0)
                {
                    GameObject Panel = GameObject.Find("Cost" + i);
                    if(Panel != null)
                    {
                        Panel.SetActive(true);
                    }
                } else if (GameManager.Cost_Panels_Active_Page_2[i] == 1)
                {
                    GameObject Panel = GameObject.Find("Cost" + i);
                    if(Panel != null)
                    {
                        Panel.SetActive(false);
                    }
                }
            }
        }
    }

    public void Customing1()
    {
        GameObject[] accessories = GameObject.FindGameObjectsWithTag("Accessory1");
        foreach(GameObject accessory in accessories) 
        {
            accessory.SetActive(false);
        }
        Accessory.SetActive(true);
    }
    public void Customing2()
    {
        GameObject[] accessories = GameObject.FindGameObjectsWithTag("Accessory2");
        foreach(GameObject accessory in accessories) 
        {
            accessory.SetActive(false);
        }
        Accessory.SetActive(true);
    }

    public void Buy10_1()
    {
        if(PlayerPrefs.GetInt("Money") >= 10)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 10);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_1[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            this.gameObject.SetActive(false);
        }
    }

    public void Buy25_1()
    {
        if(PlayerPrefs.GetInt("Money") >= 25)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 25);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_1[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            this.gameObject.SetActive(false);
        }
    }

    public void Buy50_1()
    {
        if(PlayerPrefs.GetInt("Money") >= 50)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 50);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_1[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            this.gameObject.SetActive(false);

        }
    }
    public void Buy10_2()
    {
        if(PlayerPrefs.GetInt("Money") >= 10)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 10);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_2[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            this.gameObject.SetActive(false);
        }
    }

    public void Buy25_2()
    {
        if(PlayerPrefs.GetInt("Money") >= 25)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 25);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_2[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            this.gameObject.SetActive(false);
        }
    }

    public void Buy50_2()
    {
        if(PlayerPrefs.GetInt("Money") >= 50)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 50);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_2[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            this.gameObject.SetActive(false);

        }
    }
    
}
