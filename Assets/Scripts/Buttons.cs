using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    [SerializeField] private GameObject GameMusic;
    [SerializeField] private GameObject MenuMusic;
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
        GameMusic.SetActive(true);
        MenuMusic.SetActive(false);
        check_points.SecondStart();
        //Debug.Log("NewGame has completed");
    }

    public void Continue()
    {
        check_points.DestroyMoneyChild(check_points.DestroyMoneyGameObject);
        Player.SetActive(true);
        check_points.Camera.SetActive(false);
        check_points.FindDeletingCheckpoints();
        Menu.SetActive(false);
        Fone.SetActive(false);
        Game.SetActive(true);
        Progress.SetActive(true);
        GameMusic.SetActive(true);
        MenuMusic.SetActive(false);
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
        GameMusic.SetActive(false);
        MenuMusic.SetActive(true);
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
        gamemanager.Current_CostButton.SetActive(false);
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

    public void JumpUpdate()
    {
        JumpVersion2.jumpStrength += 100f;
        Debug.Log($"{JumpVersion2.jumpStrength}");
    }  

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            PauseButton();
        }
    }
    
}
