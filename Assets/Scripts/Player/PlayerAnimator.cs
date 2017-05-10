using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public class AnimParameters
    {
        public const string jumpTrigger = "jumpTrigger";
        public const string isRun = "isRun";
        public const string isRight = "isRight";
        public const string isDead = "isDead";

        public const string player_Left_Jump = "Player_Left_Jump";
        public const string player_Right_Jump = "Player_Right_Jump";
    }

    private static PlayerAnimator _instance;

    public static PlayerAnimator Instance { get { return _instance; } }

    private Animator anim;

    public bool GetIsRight
    {
        get
        {
            return anim.GetBool(AnimParameters.isRight);
        }
    }

    public bool GetIsDead
    {
        get
        {
            return anim.GetBool(AnimParameters.isDead);
        }
    }

    public bool GetIsRun
    {
        get
        {
            return anim.GetBool(AnimParameters.isRun);
        }
    }

    public bool GetIsJumping
    {
        get
        {
            return anim.GetCurrentAnimatorStateInfo(0).IsName(AnimParameters.player_Left_Jump)
                || anim.GetCurrentAnimatorStateInfo(0).IsName(AnimParameters.player_Right_Jump);
        }
    }


    void Awake()
    {
        _instance = this;
        anim = GetComponent<Animator>();
    }

    public void TurnLeft()
    {
        if (GetIsRight)
        {
            anim.SetBool(AnimParameters.isRight, false);
        }
    }

    public void TurnRight()
    {
        if (!GetIsRight)
        {
            anim.SetBool(AnimParameters.isRight, true);
        }
    }

    public void SetIsRun(bool tf)
    {
        if (GetIsRun != tf)
        {
            anim.SetBool(AnimParameters.isRun, tf);
        }
    }

    public void SetJumpTrigger()
    {
        anim.SetTrigger(AnimParameters.jumpTrigger);
    }

    public void SetDead()
    {
        anim.SetBool(AnimParameters.isDead, true);
    }

    private void OnDestroy()
    {
        _instance = null;
    }
}
