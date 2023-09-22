using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject Skins;
    [SerializeField] private GameObject Pause;
    [SerializeField] public GameObject Player;


    
    public void NewGame()
    {
        //UpInf()
        Menu.SetActive(false);
        Player.SetActive(true);
    }

    public void Continue()
    {
        //Menu.SetActive
    }
}
