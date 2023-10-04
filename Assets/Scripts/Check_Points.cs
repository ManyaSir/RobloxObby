using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Globalization;

public class Check_Points : MonoBehaviour
{
    [SerializeField] public Transform Latest_Checkpoint;
    [SerializeField] Transform Latest_BlockWall;
    [SerializeField] public GameObject Player;
    [SerializeField] public Transform Spawn;
    [SerializeField] public Transform ZeroCount;
    [SerializeField] public Transform Latest_Checkpoint_count;
    [SerializeField] public Transform Latest_BlockWall_count;
    [SerializeField] public Transform Latest_BlockWall_place;
    [SerializeField] public GameObject Camera;
    public GameObject DestroyMoneyGameObject;
    public GameManager gamemanager;

    public static bool IsMoneyCountChanged = false;
    
    void Awake()
    {
        if(this.CompareTag("Checkpoint"))
        {
            Latest_Checkpoint_count.transform.position = Spawn.transform.position;
            //Latest_BlockWall.transform.position = new Vector3(10f, 1.5f, 8000f);
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
            //GameManager.Latest_BlockWall_pos = PlayerPrefs.GetString("StringLatest_BlockWall");
            //GameManager.Latest_BlockWall_ToVector3 = StringToVector3(GameManager.Latest_BlockWall_pos);
            //Latest_BlockWall_count.transform.position = GameManager.Latest_BlockWall_ToVector3;
            //Latest_BlockWall.transform.position = Latest_BlockWall_count.transform.position;
        } 
        
    }

    void OnTriggerEnter(Collider other) 
    { 
        if(this.CompareTag("Money") && other.CompareTag("Player")) 
        { 
            IsMoneyCountChanged = true; 
            Destroy(this.gameObject); 
            //Latest_BlockWall_count.transform.position = Latest_BlockWall_place.transform.position;
            //Latest_BlockWall.transform.position = Latest_BlockWall_count.transform.position;
            //GameManager.Latest_BlockWall_pos = Latest_BlockWall_count.transform.position.ToString();
            //PlayerPrefs.SetString("StringLatest_BlockWall", GameManager.Latest_BlockWall_pos);
            //PlayerPrefs.Save();
            gamemanager.UpInf();

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
            GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  
            
            GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);  
                
            
            Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;  
                
            
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;  
                
            
            Player.transform.position = Latest_Checkpoint.transform.position;  
            gamemanager.UpInf();

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
        PlayerPrefs.SetString("StringLatest_BlockWall", null);
        PlayerPrefs.SetInt("Money", 0   );
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
        PlayerPrefs.SetString("StringLatest_BlockWall", null);
        PlayerPrefs.SetInt("Money", 0   );
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
        //Latest_BlockWall.transform.position = new Vector3(10f, 1.5f, 8000f);
        PlayerPrefs.SetString("StringLatest_BlockWall", null);
        PlayerPrefs.Save();
        

    }
    public void FindDeletingCheckpoints()
    {
        GameObject DeleteCheckpoints;
        for (int i = 0; i != GameManager.Current_Lvl + 1; i++)
        {
            if (i == GameManager.Current_Lvl)
            {
                DeleteCheckpoints = GameObject.Find("Checkpoint " + i);
                if(DeleteCheckpoints == null)
                {
                    Debug.Log("EROROROROROROROROROORO!OR!OR!O!RO!RO!RO!R");
                }
                GameObject deleteMoney = DeleteCheckpoints.GetComponentInChildren<Transform>().Find("Money").gameObject;
                Destroy(deleteMoney.gameObject);
            } else 
            {
                DeleteCheckpoints = GameObject.Find("Checkpoint " + i);
                if(DeleteCheckpoints == null)
                {
                    Debug.Log("EROROROROROROROROROORO!OR!OR!O!RO!RO!RO!R");
                }
                Destroy(DeleteCheckpoints.gameObject);
            }
                    
        }
    }
    
    

    
}
