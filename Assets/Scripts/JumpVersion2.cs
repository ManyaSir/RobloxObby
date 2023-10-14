using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpVersion2 : MonoBehaviour
{
    public PlayerAnimations playeranimations;

    public static float jumpStrength = 5f;         // Настройка силы прыжка
    private Rigidbody rb;
    public static bool isJumping = false;
    public static int JumpCountAnim = 0;
    private bool IsGround = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector3(0, jumpStrength, 0), ForceMode.Impulse);
            isJumping = true;
            JumpCountAnim = 2;
            IsGround = false;
            playeranimations.JumpAnim();
            Debug.Log("sfdhlksfdlhkshsh");
        }

        if (rb.velocity.y < 0 && rb.velocity.y != 0 && IsGround == false)
        {
            JumpCountAnim = 3;
            playeranimations.JumpAnim();
            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Death_Ground"))   
        {
            isJumping = false;
            IsGround = true;
            FirstPersonMovement.IsWalk = 0;
            playeranimations.WalkActive();
        } else
        {
            IsGround = false;
        }
    }

    
}