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
    public Check_Points check_points;
    public GameManager gamemanager;
    bool IsPauseActive = false;


    // public void Start()
    // {
    //     gamemanager = GetComponent<GameManager>();
    // }
    
    public void NewGame()
    {
        check_points.ResetV2();
        Player.SetActive(true);
        check_points.Camera.SetActive(false);
        Menu.SetActive(false);
        Fone.SetActive(false);
        Game.SetActive(true);
        Progress.SetActive(true);
        gamemanager.UpInf();
        check_points.SecondStart();
        //Debug.Log("NewGame has completed");
    }

    public void Continue()
    {
        Player.SetActive(true);
        check_points.Camera.SetActive(false);
        Menu.SetActive(false);
        Fone.SetActive(false);
        Game.SetActive(true);
        Progress.SetActive(true);
        gamemanager.UpInf();
    }

    public void BackGameMenu()
    {
        Player.SetActive(false);
        check_points.Camera.SetActive(true);
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
        // Player.SetActive(false);
        // check_points.Camera.SetActive(true);
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            PauseButton();
        }
    }
}
