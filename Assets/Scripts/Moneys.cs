using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Moneys : MonoBehaviour
{   
    [SerializeField] int money_count;
    
    void Update(){
        this.transform.Rotate(1.0f, 0.0f, 0.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Money") && other.CompareTag("Player"))
        {   
            money_count = PlayerPrefs.GetInt("MoneyValue");
            PlayerPrefs.SetInt("MoneyValue", money_count + 5);
            PlayerPrefs.Save();
            Debug.Log(money_count + " Moneys");
            Destroy(this.gameObject);
        }
    }
}
