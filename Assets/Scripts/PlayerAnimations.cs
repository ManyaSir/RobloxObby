using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator PlayerAnimator;

    void Start ()
    {
        PlayerAnimator = GetComponent<Animator>();
    }
    public void JumpAnim()
    {
        
        PlayerAnimator.SetInteger("Animation_Number", JumpVersion2.JumpCountAnim);
    }
    public void WalkActive()
    {
        if(JumpVersion2.isJumping != true)
        {
            PlayerAnimator.SetInteger("Animation_Number", FirstPersonMovement.IsWalk);
        }
    
    }
    public void IdleActive()
    {
        if(JumpVersion2.isJumping != true)
        {
            PlayerAnimator.SetInteger("Animation_Number", 0);
        }
    }
}
