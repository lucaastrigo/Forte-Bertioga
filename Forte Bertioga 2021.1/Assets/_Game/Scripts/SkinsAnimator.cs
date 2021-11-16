using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsAnimator : MonoBehaviour
{
    public static bool player1;
    public static bool player2;
    public static bool player3;

    public RuntimeAnimatorController player1Animator;
    public RuntimeAnimatorController player2Animator;
    public RuntimeAnimatorController player3Animator;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        if (player1) anim.runtimeAnimatorController = player1Animator;
        if (player2) anim.runtimeAnimatorController = player2Animator;
        if (player3) anim.runtimeAnimatorController = player3Animator;

    }

    void Update()
    {
        
    }
}
