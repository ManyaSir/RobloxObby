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
    public static string Latest_Checkpoint_pos; 
    public static string Latest_BlockWall_pos;
    public static Vector3 Latest_BlockWall_ToVector3;
    public static Vector3 Latest_Checkpoint_ToVector3;

    
    void Start()
    {
        instance = this;
        Current_Lvl = PlayerPrefs.GetInt("Current_Lvl");
        Debug.Log("Взято сохранение прогресса");
        Money = PlayerPrefs.GetInt("Money");
        Debug.Log("Взято сохранение монет");
        lvls_count.text = "" + Current_Lvl;
        Debug.Log("Присвоено значение текущего лвла тексту");
        money_count.text = "" + Money;
        Debug.Log("Присвоено значение текущего кол-ва монет тексту");

    }
    
    void Update()
    {
        if(Check_Points.IsMoneyCountChanged == true)
        {
            Debug.Log("Увеличение монет");
            Money += 5;
            Debug.Log("Монеты + 5");
            Current_Lvl++;
            Debug.Log("Уровень + 1");
            PlayerPrefs.SetInt("Money", Money);
            Debug.Log("Сохранено значение текущего кол-ва монет");
            PlayerPrefs.SetInt("Current_Lvl", Current_Lvl);
            Debug.Log("Сохранено значение текущего лвла");
            PlayerPrefs.Save();
            Debug.Log("Сохранения сохранены");
            Check_Points.IsMoneyCountChanged = false;
            Debug.Log("Бул условие равно false");
            Debug.Log("Вызвана функция UpInf");
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

    public void UpInf()
    {
        lvls_count.text = "" + Current_Lvl;
        Debug.Log("Функция UpInf: присвоен текущий лвл тексту");
        money_count.text = "" + Money;
        Debug.Log("Функция UpInf: присвоено текущее кол-во монет тексту");
        Debug.Log("Функция UpInf выполнилась");
        //Debug.Log("UpInf has completed!");
    }

    public void ResetInf()
    {
        Money = 0;
        Current_Lvl = 0;
    }
}