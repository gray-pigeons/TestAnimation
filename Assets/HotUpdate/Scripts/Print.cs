using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Print : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"[Print] GameObject:{name}");
    }

    public void Conselose()
    {
        Debug.LogWarning("Print ........Conselose.");
    }

    private void PrivateMethod()
    {
        
    }
}