using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Custom : MonoBehaviour
{
    
    public GameObject Accessory;
    [SerializeField] public int Accessory_Index;
    public GameManager gamemanager;
    
    void Start()
    {
        if(this.CompareTag("Custom_Controller"))
        
        {    
            for(int i = 0; i != 5; i++)
            {
                GameManager.Cost_Panels_Active_Page_1[i] = PlayerPrefs.GetInt("Accesory_Number_1" + i);
            }
            for(int i = 0; i != 5; i++)
            {
                GameManager.Cost_Panels_Active_Page_2[i] = PlayerPrefs.GetInt("Accesory_Number_2" + i);
            }
            for(int i = 0; i != 5; i++)
            {
                if(GameManager.Cost_Panels_Active_Page_1[i] == 0)
                {
                    GameObject Panel = GameObject.Find("Cost_1_" + i);
                    if(Panel != null)
                    {
                        Panel.SetActive(true);
                    }
                } else if (GameManager.Cost_Panels_Active_Page_1[i] == 1)
                {
                    GameObject Panel = GameObject.Find("Cost_1_" + i);
                    if(Panel != null)
                    {
                        Panel.SetActive(false);
                        Debug.Log("Cost" + i + " куплен");
                    }
                }
            }
            for(int i = 0; i != 5; i++)
            {
                if(GameManager.Cost_Panels_Active_Page_2[i] == 0)
                {
                    GameObject Panel = GameObject.Find("Cost_2_" + i);
                    if(Panel != null)
                    {
                        Panel.SetActive(true);
                    }
                } else if (GameManager.Cost_Panels_Active_Page_2[i] == 1)
                {
                    GameObject Panel = GameObject.Find("Cost_2_" + i);
                    if(Panel != null)
                    {
                        Panel.SetActive(false);
                    }
                }
            }
            for(int i = 0; i != 5; i++)
            {
                Debug.Log("Массив 1 страница: " + GameManager.Cost_Panels_Active_Page_1[i]);
            }
            for(int i = 0; i != 5; i++)
            {
                Debug.Log("Массив 2 страница: " + GameManager.Cost_Panels_Active_Page_2[i]);
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
            PlayerPrefs.SetInt("Accesory_Number_1" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Cost_1_" + Accessory_Index);
            FalseActive.SetActive(false);
        }
    }

    public void Buy25_1()
    {
        if(PlayerPrefs.GetInt("Money") >= 25)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 25);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_1[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_1" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Cost_1_" + Accessory_Index);
            FalseActive.SetActive(false);
        }
    }

    public void Buy50_1()
    {
        if(PlayerPrefs.GetInt("Money") >= 50)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 50);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_1[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_1" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Cost_1_" + Accessory_Index);
            FalseActive.SetActive(false);

        }
    }
    public void Buy10_2()
    {
        if(PlayerPrefs.GetInt("Money") >= 10)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 10);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_2[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_2" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Cost_2_" + Accessory_Index);
            FalseActive.SetActive(false);
        }
    }

    public void Buy25_2()
    {
        if(PlayerPrefs.GetInt("Money") >= 25)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 25);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_2[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_2" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Cost_2_" + Accessory_Index);
            FalseActive.SetActive(false);
        }
    }
    
    public void Buy50_2()
    {
        if(PlayerPrefs.GetInt("Money") >= 50)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 50);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_2[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_2" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Cost_2_" + Accessory_Index);
            FalseActive.SetActive(false);

        }
    }

    public void Reseting()
    {
        for(int i = 0; i != 5; i++)
        {
            GameManager.Cost_Panels_Active_Page_1[i] = 0;
            PlayerPrefs.SetInt("Accesory_Number_1" + i, 0);
            GameManager.Cost_Panels_Active_Page_2[i] = 0;
            PlayerPrefs.SetInt("Accesory_Number_2" + i, 0);
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene("Game 1");

    }
    
}
