using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Custom : MonoBehaviour
{
    
    public GameObject Accessory;
    [SerializeField] public int Accessory_Index;
    public GameManager gamemanager;
    [SerializeField] private GameObject CostButton;
    [SerializeField] private int IndexCost;
    private int CurrentAccessoryIndex1 = -5;
    private int CurrentAccessoryIndex2 = -5;
    [SerializeField] private AudioSource Click;
    public static bool IsReady = false;




    
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
                    GameObject Panel = null;
                    GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();

                    foreach (GameObject obj in objects)
                    {
                        if (obj.name == "Lock_1_" + i)
                        {
                            Panel = obj;
                            break;
                        }
                    }                   
                    if(Panel != null)
                    {
                        Panel.SetActive(true);
                    }
                } else if (GameManager.Cost_Panels_Active_Page_1[i] == 1)
                {
                    GameObject Panel = null;
                    GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();

                    foreach (GameObject obj in objects)
                    {
                        if (obj.name == "Lock_1_" + i)
                        {
                            Panel = obj;
                            break;
                        }
                    }          
                    if(Panel != null)
                    {
                        Panel.SetActive(false);
                    }
                }
            }
            for(int i = 0; i != 5; i++)
            {
                if(GameManager.Cost_Panels_Active_Page_2[i] == 0)
                {
                    GameObject Panel = null;
                    GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();

                    foreach (GameObject obj in objects)
                    {
                        if (obj.name == "Lock_2_" + i)
                        {
                            Panel = obj;
                            break;
                        }
                    }          
                    if(Panel != null)
                    {
                        Panel.SetActive(true);
                    }
                } else if (GameManager.Cost_Panels_Active_Page_2[i] == 1)
                {
                    GameObject Panel = null;
                    GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();

                    foreach (GameObject obj in objects)
                    {
                        if (obj.name == "Lock_2_" + i)
                        {
                            Panel = obj;
                            break;
                        }
                    }          
                    if(Panel != null)
                    {
                        Panel.SetActive(false);
                    }
                }
            }
            CurrentAccessoryIndex1 = PlayerPrefs.GetInt("CurrentAccessory_1");
            CurrentAccessoryIndex2 = PlayerPrefs.GetInt("CurrentAccessory_2");

            GameObject[] CurrentAccessories = Resources.FindObjectsOfTypeAll<GameObject>();
            foreach(GameObject CurrentAccessory in CurrentAccessories)
            {
                if(CurrentAccessory.name == "BackMarker1" + CurrentAccessoryIndex1)
                {
                    CurrentAccessory.SetActive(true);
                    GameManager.CurrentIndexAccessory1 = CurrentAccessoryIndex1;
                }
            }
            foreach(GameObject CurrentAccessory in CurrentAccessories)
            {
                if(CurrentAccessory.name == "BackMarker2" + CurrentAccessoryIndex2)
                {
                    CurrentAccessory.SetActive(true);
                    GameManager.CurrentIndexAccessory2 = CurrentAccessoryIndex2;
                }
            }
            IsReady = true;

        }
    }

    public void Customing1()
    {
        
        if (GameManager.CurrentIndexAccessory1 == Accessory_Index)
        {
            Click.Play();
            Accessory.SetActive(false);    
            GameManager.CurrentIndexAccessory1 = -1;
            PlayerPrefs.SetInt("CurrentAccessory_1", -1);
            PlayerPrefs.Save();
        } else 
        {
            Click.Play();
            GameObject[] accessories = GameObject.FindGameObjectsWithTag("Accessory1");
            foreach(GameObject accessory in accessories) 
            {
                accessory.SetActive(false);
            }
            Accessory.SetActive(true);
            PlayerPrefs.SetInt("CurrentAccessory_1", Accessory_Index);
            PlayerPrefs.Save();
            GameManager.CurrentIndexAccessory1 = Accessory_Index;
        }
    }
    public void Customing2()
    {
        if (GameManager.CurrentIndexAccessory2 == Accessory_Index)
        {
            Click.Play();
            Accessory.SetActive(false);    
            GameManager.CurrentIndexAccessory2 = -1;
            PlayerPrefs.SetInt("CurrentAccessory_2", -1);
            PlayerPrefs.Save();
        } else
        {
            Click.Play();
            GameObject[] accessories = GameObject.FindGameObjectsWithTag("Accessory2");
            foreach(GameObject accessory in accessories) 
            {
                accessory.SetActive(false);
            }
            Accessory.SetActive(true);
            PlayerPrefs.SetInt("CurrentAccessory_2", Accessory_Index);
            PlayerPrefs.Save();
            GameManager.CurrentIndexAccessory2 = Accessory_Index;
        }
    }

    public void Buy10_1()
    {
        if(PlayerPrefs.GetInt("Money") >= 10)
        {
            Click.Play();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 10);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_1[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_1" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Lock_1_" + Accessory_Index);
            gamemanager.Current_CostButton.SetActive(false);
            FalseActive.SetActive(false);
        }
    }

    public void Buy25_1()
    {
        if(PlayerPrefs.GetInt("Money") >= 25)
        {
            Click.Play();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 25);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_1[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_1" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Lock_1_" + Accessory_Index);
            gamemanager.Current_CostButton.SetActive(false);
            FalseActive.SetActive(false);
        }
    }

    public void Buy50_1()
    {
        if(PlayerPrefs.GetInt("Money") >= 50)
        {
            Click.Play();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 50);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_1[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_1" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Lock_1_" + Accessory_Index);
            gamemanager.Current_CostButton.SetActive(false);
            FalseActive.SetActive(false);

        }
    }
    public void Buy10_2()
    {
        if(PlayerPrefs.GetInt("Money") >= 10)
        {
            Click.Play();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 10);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_2[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_2" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Lock_2_" + Accessory_Index);
            gamemanager.Current_CostButton.SetActive(false);
            FalseActive.SetActive(false);
        }
    }

    public void Buy25_2()
    {
        if(PlayerPrefs.GetInt("Money") >= 25)
        {
            Click.Play();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 25);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_2[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_2" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Lock_2_" + Accessory_Index);
            gamemanager.Current_CostButton.SetActive(false);
            FalseActive.SetActive(false);
        }
    }
    
    public void Buy50_2()
    {
        if(PlayerPrefs.GetInt("Money") >= 50)
        {
            Click.Play();
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - 50);
            PlayerPrefs.Save();
            GameManager.Cost_Panels_Active_Page_2[Accessory_Index] = 1;
            PlayerPrefs.SetInt("Accesory_Number_2" + Accessory_Index, 1);
            PlayerPrefs.Save();
            gamemanager.UpInf();
            GameObject FalseActive = GameObject.Find("Lock_2_" + Accessory_Index);
            gamemanager.Current_CostButton.SetActive(false);
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
    
    public void Accessory_Cost_Button_1()
    {
        Click.Play();
        gamemanager.Current_CostButton.SetActive(false);
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in objects)
        {
            if (obj.name == "Cost_1_" + IndexCost)
            {
                CostButton = obj;
                break;
            }
        }

        CostButton.SetActive(true);
        gamemanager.Current_CostButton = CostButton;
    }

    public void Accessory_Cost_Button_2()
    {
        Click.Play();
        gamemanager.Current_CostButton.SetActive(false);
        GameObject[] objects = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject obj in objects)
        {
            if (obj.name == "Cost_2_" + IndexCost)
            {
                CostButton = obj;
                break;
            }
        }

        CostButton.SetActive(true);
        gamemanager.Current_CostButton = CostButton;
    }
}
