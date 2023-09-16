using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static Transform Latest_Checkpoint_count;
    public static Transform Latest_BlockWall_count;
    [SerializeField] KeyCode keyOne;
    public int Money = 0;
    public int Current_Lvl = 0;
    private Text lvls_count;
    private Text money_count;   

    void Awake()
    {
        Latest_Checkpoint_count.transform.position = Check_Points.Spawn.transform.position;
    }
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
            PlayerPrefs.SetInt("Money", Money);
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