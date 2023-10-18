using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

public class Press : MonoBehaviour
{
    [SerializeField] private float3 StartPosition;
    private bool isDown = true;
    private float StartYPosition;

    void Update()
    {
        if(isDown)
        {
            Debug.Log("StartPosition = " + StartPosition);
            StartPosition.y += -0.005f;
            //StartPosition.z = 0f;
            if(StartPosition.y == -0.2f)
            {
                isDown = false;
            }
            this.transform.position = StartPosition;
        }
        
    }
}

