using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleAni : MonoBehaviour
{
    public void FirstEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }

    public void TwoEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }

    public void ThreeEvent(string s)
    {
        Debug.Log("PrintEvent: " + s + " called at: " + Time.time);
    }

    Animation animation;
    Animator animator;
    private void Start()
    {
        animation = GetComponent<Animation>();
        animator = GetComponent<Animator>();
    }


}
