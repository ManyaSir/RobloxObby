using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressMoving : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 StartPosition;
    [SerializeField] private int Speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartPosition = transform.position;
        StartPosition += new Vector3(-20, -20, -20);
        rb.MovePosition(StartPosition);
    }
    
}
