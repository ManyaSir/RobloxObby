using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{ 
    public Buttons buttons;    
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            buttons.FinishTrigger();
            Debug.Log("Да-да-да-да-да");
        }
    }
}
