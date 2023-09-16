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
    //public static Trans Spawn = new Vector3(7.0f, 0.5f, 0.0f);
    public static bool IsMoneyCountChanged = false;
    
    void Awake()
    {
        if(this.CompareTag("Checkpoint"))
        {
            Latest_Checkpoint_count.transform.position = Spawn.transform.position;
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
            
            GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  

            
            GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);  
                
            
            Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;  
                
            
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;  
                
            
            Player.transform.position = Latest_Checkpoint.transform.position;


            GameManager.Latest_BlockWall_pos = PlayerPrefs.GetString("StringLatest_BlockWall");


            GameManager.Latest_BlockWall_ToVector3 = StringToVector3(GameManager.Latest_BlockWall_pos);

            
            Latest_BlockWall_count.transform.position = GameManager.Latest_BlockWall_ToVector3;
            

            Latest_BlockWall.transform.position = Latest_BlockWall_count.transform.position;
        } 
    }

    void OnTriggerEnter(Collider other) 
    { 
        if(this.CompareTag("Money") && other.CompareTag("Player")) 
        { 
            IsMoneyCountChanged = true; 
            Destroy(this.gameObject); 
            Latest_BlockWall_count.transform.position = Latest_BlockWall_place.transform.position;
            Latest_BlockWall.transform.position = Latest_BlockWall_count.transform.position;
            GameManager.Latest_BlockWall_pos = Latest_BlockWall_count.transform.position.ToString();
            PlayerPrefs.SetString("StringLatest_BlockWall", GameManager.Latest_BlockWall_pos);
            PlayerPrefs.Save();
        } 
        if(this.CompareTag("Checkpoint") && other.CompareTag("Player"))
        {
            Latest_Checkpoint_count.transform.position = this.transform.position;
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;
            GameManager.Latest_Checkpoint_pos = Latest_Checkpoint_count.transform.position.ToString();
            PlayerPrefs.SetString("StringLatest_Checkpoint", GameManager.Latest_Checkpoint_pos);
            PlayerPrefs.Save();

        }
        if(this.CompareTag("Death_Ground") && other.CompareTag("Player"))
        {
            GameManager.Latest_Checkpoint_pos = PlayerPrefs.GetString("StringLatest_Checkpoint");  
            
            GameManager.Latest_Checkpoint_ToVector3 = StringToVector3(GameManager.Latest_Checkpoint_pos);  
                
            
            Latest_Checkpoint_count.transform.position = GameManager.Latest_Checkpoint_ToVector3;  
                
            
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;  
                
            
            Player.transform.position = Latest_Checkpoint.transform.position;  
        }
    }

    public void Reset()
    {
        PlayerPrefs.SetString("StringLatest_Checkpoint", null);
        PlayerPrefs.SetString("StringLatest_BlockWall", null);
        PlayerPrefs.SetInt("Money", 0   );
        PlayerPrefs.SetInt("Current_Lvl", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Game");
    }


    
}
