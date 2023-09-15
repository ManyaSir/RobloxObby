using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    [SerializeField] public static GameObject Latest_Checkpoint;
    [SerializeField] private Rigidbody rg_Player;
    [SerializeField] private Transform tr_Player;
    
    void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Checkpoint") && other.CompareTag("Player"))
        {
            Latest_Checkpoint.Transform = this.Transform;
            
        }
    }

    void Start()
    {
        Latest_Checkpoint.Transform = GameManager.Latest_Checkpoint_value.Transform;
        tr_Player.Transform = Latest_Checkpoint.Transform;
    }
}
