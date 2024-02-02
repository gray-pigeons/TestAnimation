using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAni : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        AnimationEvent animationEvent = new AnimationEvent();
        animationEvent.functionName = "PrintLog";
        animationEvent.intParameter = 100;
        animationEvent.time = 1.5f;
        var clip = animator.runtimeAnimatorController.animationClips[0];
        clip.AddEvent(animationEvent);
    }

    void PrintLog(int i)
    {
        print("PrintLog: " + i + " called at: " + Time.time);
    }


}
