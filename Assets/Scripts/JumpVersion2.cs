using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpVersion2 : MonoBehaviour
{
    public static float jumpStrength = 5f; // Переменная для задания высоты прыжка
    
    private bool canJump = true; // Флаг, показывающий, может ли персонаж прыгнуть

    private Rigidbody rb;

    public PlayerAnimations playeranimations;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Jump();
        }
    }

    public void Jump()
    {
        //playeranimations.JumpAnim();
        rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        canJump = false;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Death_Ground"))
        {
            canJump = true;
        }
    }
}