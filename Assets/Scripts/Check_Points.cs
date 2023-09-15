using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Check_Points : MonoBehaviour
{
    [SerializeField] public static GameObject Latest_Checkpoint;
    [SerializeField] private Rigidbody rg_Player;
    [SerializeField] private Transform tr_Player;
    public static bool isChanged = false;
    
    void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Checkpoint") && other.CompareTag("Player"))
        {
            Latest_Checkpoint.transform.position = this.transform.position;
            isChanged = true;
        }
    }

    void Start()
    {
        if (GameManager.isStartGame == true)
        {
            //GameManager.Latest_Checkpoint_value.transform.position = Latest_Checkpoint.transform.position;
            GameManager.Latest_Checkpoint_value = Latest_Checkpoint.transform.position;
            GameManager.isStartGame = false;
        }
        //Latest_Checkpoint.transform.position = GameManager.Latest_Checkpoint_value.transform.position;
        Latest_Checkpoint.transform.position = GameManager.Latest_Checkpoint_value;
        //tr_Player.transform.position = GameManager.Latest_Checkpoint_value.transform.position;
        tr_Player.transform.position = GameManager.Latest_Checkpoint_value;
    }
}
