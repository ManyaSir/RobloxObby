using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Numerics;


public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject Menu;
    [SerializeField] private GameObject Settings;
    [SerializeField] private GameObject Skins;
    [SerializeField] public GameObject Pause;
    [SerializeField] public GameObject Player;
    [SerializeField] private GameObject Progress;
    [SerializeField] private GameObject Game;
    [SerializeField] private GameObject GameMusic;
    [SerializeField] private GameObject MenuMusic;
    [SerializeField] private GameObject Page1;
    [SerializeField] private GameObject Page2;
    [SerializeField] private GameObject NextButton;
    [SerializeField] private GameObject BackButton;
    [SerializeField] private AudioSource Click;
    [SerializeField] private JumpVersion2 jumpversion2Script;
    [SerializeField] private FirstPersonMovement firstpersonmovementscript;
    // [SerializeField] private Image PauseMeshRender;
    // [SerializeField] private Button ButtonPause;
    public Check_Points check_points;
    public GameManager gamemanager;
    public FirstPersonLook firstpersonlook; 
    bool IsPauseActive = false;
    private int CurrentPage = 1;
    public LevelsChange levelschange;
    public SoundControllerVersion2 soundcontrollerversion2;
    public SoundControllerVersion3 soundcontrollerversion3;
    private int IsStartScene = 0;
    private int IsNeed = 0;
    [SerializeField] private GameObject Downloading_Obj;
    private bool IsNeedRemoveDownloading = true;
    [SerializeField] private GameObject Accessory_Controller;
    [SerializeField] private GameObject Audio_Controller_2;
    [SerializeField] private GameObject Audio_Controller_3;
    [SerializeField] private GameObject RotationModel;
    [SerializeField] private PlayerRotation RotationModelScript;
    public DoTween dotween;
    private bool Process = false;
    float delayStartTime;
    public DoTween dotween2;

    



    void Start()
    {
        StartCoroutine(SpawnLoop());
        Cursor.lockState = CursorLockMode.None;
        Downloading_Obj.SetActive(true);
        Audio_Controller_2.SetActive(true);
        Audio_Controller_3.SetActive(true);
        Accessory_Controller.SetActive(true);


        IEnumerator SpawnLoop()
        {
            while(IsNeedRemoveDownloading)
            {
                yield return new WaitForSeconds(1f);
                if( Custom.IsReady == true && SoundControllerVersion2.IsReady == true && SoundControllerVersion3.IsReady == true)
                {
                    Audio_Controller_3.SetActive(false);
                    Accessory_Controller.SetActive(false);
                    Downloading_Obj.SetActive(false);
                    IsNeedRemoveDownloading = false;
                    Audio_Controller_2.SetActive(false);

                }
            }
        }
        
       


    }
    
    
    public void NewGame()
    {
        Click.Play();
        Downloading_Obj.SetActive(true);
        Audio_Controller_3.SetActive(true);
        check_points.ResetV2();
        PlayerPrefs.SetInt("MapStatus", 1);
        PlayerPrefs.Save();
        levelschange.CheckingMapStatus();
        Player.SetActive(true);
        check_points.Camera.SetActive(false);
        Menu.SetActive(false);
        Game.SetActive(true);
        Settings.SetActive(false);
        Progress.SetActive(true);
        gamemanager.UpInf();
        GameMusic.SetActive(true);
        MenuMusic.SetActive(false);
        check_points.SecondStart();
        Cursor.lockState = CursorLockMode.Locked;
        RotationModel.SetActive(false);
        
        IsNeedRemoveDownloading = true;
        Invoke("checkingDownloading", 1f);
    }

    public void checkingDownloading()
    {
        while(IsNeedRemoveDownloading)
        {
            if(SoundControllerVersion2.IsReady == true && SoundControllerVersion3.IsReady == true)
            {
                Audio_Controller_3.SetActive(false);
                Downloading_Obj.SetActive(false);
                IsNeedRemoveDownloading = false;
            }
        }
    }

    public void Continue()
    {
        Click.Play();
        Downloading_Obj.SetActive(true);
        Audio_Controller_3.SetActive(true);
        check_points.DestroyMoneyChild(check_points.DestroyMoneyGameObject);
        Player.SetActive(true);
        check_points.Camera.SetActive(false);
        check_points.FindDeletingCheckpoints();
        Menu.SetActive(false);
        Game.SetActive(true);
        Settings.SetActive(false);
        Progress.SetActive(true);
        GameMusic.SetActive(true);
        MenuMusic.SetActive(false);
        gamemanager.UpInf();
        Cursor.lockState = CursorLockMode.Locked;
        IsNeedRemoveDownloading = true;
        RotationModel.SetActive(false);
        Invoke("checkingDownloading", 1f);
        

    }

    public void BackGameMenu()
    {
        Click.Play();
        check_points.DeathGroundAndPlayer();
        Cursor.lockState = CursorLockMode.None;
        Player.SetActive(false);
        check_points.Camera.transform.position = check_points.CameraPositionStart;
        check_points.Camera.transform.rotation = check_points.CameraRotationStart;
        firstpersonlook.FPL_Camera.SetActive(true);
        check_points.Camera.SetActive(true);
        Menu.SetActive(true);
        Game.SetActive(false);
        Progress.SetActive(false);
        Pause.SetActive(false);
        GameMusic.SetActive(false);
        MenuMusic.SetActive(true);
        RotationModel.SetActive(true);
        // check_points.GameOverMenu.SetActive(false);
        // check_points.GameOverTextV1.SetActive(false);
        // check_points.GameOverTextV2.SetActive(false);
        // check_points.GameOverTextV3.SetActive(false);
        // check_points.PlayerModel.SetActive(true);
    }

    public void SettingsButton()
    {
        Click.Play();
        Settings.SetActive(true);
        soundcontrollerversion2.UpdateInfoSound();
        soundcontrollerversion3.UpdateInfoSound();
        RotationModelScript.enabled = false;

    }

    public void BackSettingsMenu()
    {
        Click.Play();
        RotationModelScript.enabled = true;

    }

    public void SkinsButton()
    {
        Click.Play();
        Menu.SetActive(false);
        Skins.SetActive(true);
    }

    public void BackSkinsMenu()
    {
        Click.Play();
        Menu.SetActive(true);
        gamemanager.Current_CostButton.SetActive(false);
        Skins.SetActive(false);
        if(CurrentPage == 2)
        {
            Page2.SetActive(false);
            Page1.SetActive(true);
        }
        CurrentPage = 1;
        NextButton.SetActive(true);
        BackButton.SetActive(false);
        firstpersonmovementscript.enabled = true;
        jumpversion2Script.enabled = true;
    }

    public void PauseButton()
    {
        firstpersonlook.PauseDataSave();
        Cursor.lockState = CursorLockMode.None;
        check_points.Camera.transform.position = firstpersonlook.CameraPosition;
        check_points.Camera.transform.rotation = firstpersonlook.CameraRotation;
        firstpersonmovementscript.enabled = false;
        jumpversion2Script.enabled = false;
        check_points.Camera.SetActive(true);
        firstpersonlook.FPL_Camera.SetActive(false);
        Pause.SetActive(true);
        soundcontrollerversion2.UpdateInfoSound();
        soundcontrollerversion3.UpdateInfoSound();

    }

    public void BackPause()
    {
        Click.Play();
        Cursor.lockState = CursorLockMode.Locked;
        firstpersonlook.FPL_Camera.SetActive(true);
        check_points.Camera.SetActive(false);
        check_points.Camera.transform.position = check_points.CameraPositionStart;
        check_points.Camera.transform.rotation = check_points.CameraRotationStart;
        firstpersonmovementscript.enabled = true;
        jumpversion2Script.enabled = true;
        
        
    }
    void StartDelay()
    {
        delayStartTime = Time.time;
    }

    public void JumpUpdate()
    {
        JumpVersion2.jumpStrength += 100f;
        Debug.Log($"{JumpVersion2.jumpStrength}");
    }  

    void Update()
    {
        // if(Input.GetKey(KeyCode.Escape) && Game.activeSelf && !Check_Points.IsGameOver)
        // {
        //     if (DoTween.IsActivePause)
        //     {
        //         dotween.PauseFadeOut();
        //         Debug.Log("Закрывашка дотвин");
                
        //     } else 
        //     {
        //         PauseButton();
        //         Debug.Log("Открывашка пауза");

                
        //     }
        // }
        Invoke("EscInput", 2f);
    }
    public void NextPage()
    {
        if(CurrentPage == 1)
        {
            Click.Play();
            Page2.SetActive(true);
            Page1.SetActive(false);
            NextButton.SetActive(false);
            BackButton.SetActive(true);
            CurrentPage = 2;
        } else if (CurrentPage == 2)
        {
            Page1.SetActive(true);
            Click.Play();
            Page2.SetActive(false);
            NextButton.SetActive(true);
            BackButton.SetActive(false);
            CurrentPage = 1;

        }
    }

    public void EscInput()
    {
        if(!Process)
        {    
            if(Input.GetKey(KeyCode.Escape) && Game.activeSelf && !Check_Points.IsGameOver)
            {
                if (DoTween.IsActivePause)
                {
                    Process = true;
                    dotween.PauseFadeOut();
                    BackPause();
                    Debug.Log("Закрывашка дотвин");
                    Process = false;
                    
                } else 
                {
                    Process = true;
                    PauseButton();
                    dotween.PauseFadeIn();
                    Debug.Log("Открывашка пауза");
                    Process = false;  
                }
            }
        }
    }
    
}
