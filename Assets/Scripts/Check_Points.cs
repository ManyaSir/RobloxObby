using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check_Points : MonoBehaviour
{
    [SerializeField] GameObject Latest_Checkpoint;
    [SerializeField] GameObject Latest_BlockWall;
    [SerializeField] private GameObject Player;
    [SerializeField] private Transform Spawn_tr;
    public static GameObject Spawn;
    public static bool IsMoneyCountChanged = false;
    
    void Awake()
    {
        Spawn.transform.position = Spawn_tr.transform.position;
        Debug.Log("" + Spawn.transform.position);
    }
    
    void Start()
    {
        Latest_Checkpoint.transform.position = GameManager.Latest_Checkpoint_count.transform.position;
        Player.transform.position = Latest_Checkpoint.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Latest_Checkpoint") && other.CompareTag("Money"))
        {
            IsMoneyCountChanged = true;
            other.enabled = false;
        }
        if(this.CompareTag("Checkpoint") && other.CompareTag("Player"))
        {
            GameManager.Latest_Checkpoint_count.transform.position = this.transform.position;
            Latest_Checkpoint.transform.position = GameManager.Latest_Checkpoint_count.transform.position;

        }
    }

    
}
