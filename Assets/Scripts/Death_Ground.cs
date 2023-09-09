using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Death_Ground : MonoBehaviour
{
    public GameObject Player;
    public GameObject Spawn;
    public GameObject Checkpoint_1;
    public GameObject Latest_Checkpoint;
    [SerializeField] private Transform Player_tr;
    [SerializeField] private Rigidbody Player_Rg;
    void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Death_Ground") && other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Game");
            System.Threading.Thread.Sleep(6000);
            Latest_Checkpoint.transform.position = Checkpoint_1.transform.position;
            Player.transform.position = Latest_Checkpoint.transform.position;
           
        }
    }
    
}
