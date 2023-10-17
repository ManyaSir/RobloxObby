using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour
{
 private float speedMove = 2.0f;
    void Start()
    {
        
    }


    void Update()
    {
        Vector3 p = new Vector3(-22.652f, -3.892f, 14.861f);
        p.x = -22.652f;
        p.y = -3.87f;
        p.z = 14.861f;
        gameObject.transform.position = p;
    }
}
