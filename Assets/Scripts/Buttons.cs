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
    [SerializeField] private GameObject Progress;
    [SerializeField] private GameObject Fone;
    [SerializeField] private GameObject Game;


    
    public void NewGame()
    {
        //Reset();
        Menu.SetActive(false);
        Fone.SetActive(false);
        Game.SetActive(true);
        Progress.SetActive(true);
    }

    public void Continue()
    {
        Menu.SetActive(false);
        Fone.SetActive(false);
        Game.SetActive(true);
        Progress.SetActive(true);
    }

    public void BackGameMenu()
    {
        Menu.SetActive(true);
        Fone.SetActive(true);
        Game.SetActive(false);
        Progress.SetActive(false);
        Pause.SetActive(false);
    }

    public void SettingsButton()
    {
        Settings.SetActive(true);
    }

    public void BackSettingsMenu()
    {
        Settings.SetActive(false);
    }

    public void SkinsButton()
    {
        Menu.SetActive(false);
        Skins.SetActive(true);
    }

    public void BackSkinsMenu()
    {
        Menu.SetActive(true);
        Skins.SetActive(false);
    }

    public void PauseButton()
    {
        Pause.SetActive(true);
    }

    public void BackPause()
    {
        Pause.SetActive(false);
    }
}
