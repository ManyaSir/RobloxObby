using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator PlayerAnimator;
    public Animation Jumping;

    void Start ()
    {
        PlayerAnimator = GetComponent<Animator>();
    }
    public void JumpAnim()
    {
        
        PlayerAnimator.SetInteger("Animation_Number", JumpVersion2.JumpCountAnim);
        Debug.Log("Current Animation_Number: " + PlayerAnimator.GetInteger("Animation_Number"));
    }
    public void WalkActive()
    {
        if(JumpVersion2.isJumping != true)
        {
            PlayerAnimator.SetInteger("Animation_Number", FirstPersonMovement.IsWalk);
            Debug.Log("Current Animation_Number: " + PlayerAnimator.GetInteger("Animation_Number"));
        }
    
    }
    public void IdleActive()
    {
        if(JumpVersion2.isJumping != true)
        {
            PlayerAnimator.SetInteger("Animation_Number", 0);
            Debug.Log("Current Animation_Number: " + PlayerAnimator.GetInteger("Animation_Number"));
        }
    }
}
