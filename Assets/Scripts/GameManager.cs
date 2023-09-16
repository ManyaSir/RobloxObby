using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] KeyCode keyOne;
    public int Money = 0;
    public int Current_Lvl = 0;
    [SerializeField] private Text lvls_count;
    [SerializeField] private Text money_count;   

    
    void Start()
    {
        instance = this;
        Current_Lvl = PlayerPrefs.GetInt("Current_Lvl");
        Money = PlayerPrefs.GetInt("Money");
        lvls_count.text = "" + Current_Lvl;
        money_count.text = "" + Money;
    }
    
    void Update()
    {
        if(Check_Points.IsMoneyCountChanged == true)
        {
            Money += 5;
            Current_Lvl++;
            PlayerPrefs.SetInt("Money", Money);
            PlayerPrefs.SetInt("Current_Lvl", Current_Lvl);
            PlayerPrefs.Save();
            Check_Points.IsMoneyCountChanged = false;
            UpInf();
            
        }
    }

    void FixedUpdate()
    {
        if(Input.GetKey(keyOne)) 
        {
            SceneManager.LoadScene("Game");
        }
    }

    void UpInf()
    {
        lvls_count.text = "" + Current_Lvl;
        money_count.text = "" + Money;
    }
}