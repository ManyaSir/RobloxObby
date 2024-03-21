using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;

public class Check_Points : MonoBehaviour
{
    [SerializeField] public Transform Latest_Checkpoint;
    [SerializeField] public GameObject Player;
    [SerializeField] public Transform Spawn;
    [SerializeField] public Transform ZeroCount;
    [SerializeField] public Transform Latest_Checkpoint_count;
    [SerializeField] public GameObject Camera;
    public Vector3 CameraPositionStart;
    public Quaternion CameraRotationStart;
    public GameObject DestroyMoneyGameObject;
    public GameManager gamemanager;
    public Finish finishscript;
    [SerializeField] public GameObject GameOverMenu;
    [SerializeField] public GameObject GameOverTextV1;
    [SerializeField] public GameObject GameOverTextV2;
    [SerializeField] public GameObject GameOverTextV3;
    [SerializeField] private AudioSource DeathSound;
    [SerializeField] private FirstPersonMovement firstpersonmovementscript;
    [SerializeField] private JumpVersion2 jumpversion2Script;
    public static bool IsGameOver = false;
    public FirstPersonLook firstpersonlook; 
    [SerializeField] public GameObject PlayerModel;
    public Buttons buttons;
    public DoTween dotween;
    public Collider PlayerCollider;
    private string LatestCheckpointNumber;

    [SerializeField] public GameObject GameOverTextV4;

    public DoTween dotween2;


    

    public static bool IsMoneyCountChanged = false;
    
    void Awake()
    {
        if(this.CompareTag("Checkpoint"))
        {
            Latest_Checkpoint_count.transform.position = Spawn.transform.position;
            CameraPositionStart = Camera.transform.position;
            CameraRotationStart = Camera.transform.rotation;
        }
        
        
    }
    
    Vector3 StringToVector3(string input)
    {
        string[] values = input.Split(',', '(', ')');
        float x = float.Parse(values[1].Trim(), CultureInfo.InvariantCulture.NumberFormat);
        float y = float.Parse(values[2].Trim(), CultureInfo.InvariantCulture.NumberFormat);
        float z = float.Parse(values[3].Trim(), CultureInfo.InvariantCulture.NumberFormat);
        return new Vector3(x, y, z);
        
    }
    
    void Start()  
    {  

        if(this.CompareTag("Checkpoint"))  
        {  
            Player.SetActive(false);
            Camera.SetActive(true);
            GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  
            GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);    
            Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;     
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;    
            Player.transform.position = Latest_Checkpoint.transform.position;
        } 
        
    }

    void OnTriggerEnter(Collider other) 
    { 
        if (other == null) {
            return;
        }

        if (this.CompareTag("Money") && other.CompareTag("Player")) 
        { 
            Buttons.IsPlayMoneySound = true;
            IsMoneyCountChanged = true; 
            LatestCheckpointNumber = this.name.Replace("Money ", "");
            PlayerPrefs.SetInt("LatestNumberCheckpoint", int.Parse(LatestCheckpointNumber));
            PlayerPrefs.Save();
            this.gameObject.SetActive(false);

            if (gamemanager != null) 
            {
                gamemanager.UpInf();
            }

        } 
        if(this.CompareTag("Checkpoint") && other.CompareTag("Player"))
        {
            Latest_Checkpoint_count.transform.position = this.transform.position;
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;
            GameManager.Latest_Checkpoint_pos = Latest_Checkpoint_count.transform.position.ToString();
            PlayerPrefs.SetString("StringLatest_Checkpoint", GameManager.Latest_Checkpoint_pos);
            PlayerPrefs.Save();
            gamemanager.UpInf();


        }
        if(this.CompareTag("Death_Ground") && other.CompareTag("Player"))
        {
            // GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  
            
            // GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);  
                
            
            // Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;  
                
            
            // Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;  
                
            
            // Player.transform.position = Latest_Checkpoint.transform.position;  
            // gamemanager.UpInf();
            buttons.BackPause();
            dotween.PauseFadeOut();
            PlayerModel.SetActive(false);
            firstpersonlook.PauseDataSave();
            Cursor.lockState = CursorLockMode.None;
            Camera.transform.position = firstpersonlook.CameraPosition;
            Camera.transform.rotation = firstpersonlook.CameraRotation;
            firstpersonmovementscript.enabled = false;
            jumpversion2Script.enabled = false;
            Camera.SetActive(true);
            firstpersonlook.FPL_Camera.SetActive(false);
            IsGameOver = true;
            GameOverMenu.SetActive(true);
            DeathSound.Play();
            Cursor.lockState = CursorLockMode.None;
            PlayerCollider.enabled = false;
            if(this.name == "Death_Ground")
            {
                GameOverTextV1.SetActive(true);
            } else if(this.name == "Press")
            {
                GameOverTextV2.SetActive(true);
            } else if (this.name == "PressWithThorns")
            {
                GameOverTextV3.SetActive(true);
            } else
            {
                GameOverTextV4.SetActive(true);
            }
            dotween2.PauseFadeIn();

        }
        if(this.CompareTag("Latest_Checkpoint") && other.CompareTag("Checkpoint"))
        {
            DestroyMoneyGameObject = other.gameObject;
            DestroyMoneyGameObject = GameObject.Find("Money");
        }
    }

    public void Reset()
    {
        Latest_Checkpoint_count.transform.position = Spawn.transform.position;
        GameManager.Latest_Checkpoint_pos = Latest_Checkpoint_count.transform.position.ToString();
        PlayerPrefs.SetString("StringLatest_Checkpoint", GameManager.Latest_Checkpoint_pos);
        PlayerPrefs.SetInt("Current_Lvl", 0);
        PlayerPrefs.Save();
        gamemanager.ResetInf();
        SceneManager.LoadScene("Game 1");
    }

    public void ResetV2()
    {
        Latest_Checkpoint_count.transform.position = Spawn.transform.position;
        GameManager.Latest_Checkpoint_pos = Latest_Checkpoint_count.transform.position.ToString();
        PlayerPrefs.SetString("StringLatest_Checkpoint", GameManager.Latest_Checkpoint_pos);
        PlayerPrefs.SetInt("Current_Lvl", 0);
        PlayerPrefs.Save();
        gamemanager.ResetInf();
        gamemanager.UpInf();

    }

    public void DestroyMoneyChild(GameObject MoneyCount)
    {
        
        if(MoneyCount != null)
        {
            MoneyCount.gameObject.SetActive(false);
        } else 
        {
            Debug.Log("Crash");
        }
    } 

    public void SecondStart()
    {
        GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  
        GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);  
        Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;         
        Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;  
        Player.transform.position = Latest_Checkpoint.transform.position;
        PlayerPrefs.SetString("StringLatest_BlockWall", null);
        GameManager.Current_Lvl = 0;
        PlayerPrefs.SetInt("Current_Lvl", 0);
        PlayerPrefs.Save();
        

    }

    public void FindDeletingCheckpoints()
    {
        for (int i = 0; i != GameManager.Current_Lvl + 1; i++)
        {
            GameObject[] deleteCheckpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
            foreach (GameObject checkpoint in deleteCheckpoints)
            {
                if (checkpoint.name == "Checkpoint " + i)
                {
                    if (i == GameManager.Current_Lvl)
                    {
                        if(checkpoint != null )
                        {
                            if(checkpoint.transform.Find("Money") != null) 
                            {
                                GameObject deleteMoney = checkpoint.transform.Find("Money").gameObject;
                                deleteMoney.SetActive(false);
                            }
                        }
                    }
                    checkpoint.SetActive(false);
                    break;
                }
            }
        }
    }

   public void DeathGroundAndPlayer()
   {
        Debug.Log("Начало");
        dotween2.PauseFadeOut();
        IsGameOver = false;
        GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  
            
        GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);  
                
            
        Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;  
                
            
        Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;  
                
            
        Player.transform.position = Latest_Checkpoint.transform.position;  
        Cursor.lockState = CursorLockMode.Locked;
        //GameOverMenu.SetActive(false);
        GameOverTextV1.SetActive(false);
        GameOverTextV2.SetActive(false);
        GameOverTextV3.SetActive(false);
        GameOverTextV4.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        firstpersonlook.FPL_Camera.SetActive(true);
        Camera.SetActive(false);
        Camera.transform.position = CameraPositionStart;
        Camera.transform.rotation = CameraRotationStart;
        firstpersonmovementscript.enabled = true;
        jumpversion2Script.enabled = true;
        PlayerModel.SetActive(true);
        PlayerCollider.enabled = true;

        gamemanager.UpInf();
   }

   public void FindingAllMoneyAndActivate()
   {
        // GameObject[] AllMoney = GameObject.FindGameObjectsWithTag("Money");
        // foreach (GameObject MoneyMoney in AllMoney)
        // {
        //     if (MoneyMoney.name == "Money")
        //     {
        //         if(MoneyMoney != null)
        //         {
        //             MoneyMoney.SetActive(true);
        //         }
        //     }
        // }
        GameObject[] moneyObjects = GameObject.FindObjectsOfType<GameObject>(true);

        for (int i = 1; i <= 31; i++)
        {
            foreach (GameObject moneyObject in moneyObjects)
            {
                if (moneyObject.name == "Money " + i && moneyObject != null)
                {
                    moneyObject.SetActive(true);
                }
            }
        }
   }
    
    
    

    
}
