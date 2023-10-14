using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearingAccessories : MonoBehaviour
{
    [SerializeField] private GameObject Marker;
    [SerializeField] private GameObject Accessory;
    

    void Update()
    {
        if(Marker.activeSelf)
        {
            Accessory.SetActive(true);
        } else
        {
            Accessory.SetActive(false);
        }
    }
}
