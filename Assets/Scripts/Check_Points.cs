using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check_Points : MonoBehaviour
{
    [SerializeField] Transform Latest_Checkpoint;
    [SerializeField] Transform Latest_BlockWall;
    [SerializeField] private GameObject Player;
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
    
    void Start()
    {
        if(this.CompareTag("Checkpoint"))
        {
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;
            Player.transform.position = Latest_Checkpoint.transform.position;
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
        } 
        if(this.CompareTag("Checkpoint") && other.CompareTag("Player"))
        {
            Latest_Checkpoint_count.transform.position = this.transform.position;
            Latest_Checkpoint.transform.position = Latest_Checkpoint_count.transform.position;

        }
    }

    
}
