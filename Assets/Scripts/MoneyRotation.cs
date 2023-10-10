using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyRotation : MonoBehaviour
{
    public GameObject Money;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Money.transform.Rotate(0.8f,0,0);
    }
}
