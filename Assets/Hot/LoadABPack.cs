using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadABPack :MonoBehaviour
{
    public static void LoadABPackage()
    {
        Debug.LogWarning("LoadABPackage........");
       
    }

    private void Start()
    {
        ABManager.Instance.LoadResourceAsync<GameObject>("plane.unity3d", "plane", (go) => { 
            GameObject gameObject = go as GameObject;
            if (gameObject != null)
            {
               GameObject g = Instantiate(gameObject);
                Debug.LogWarning("加载AB包成功");
            }
        });
    }

    public static void Print()
    {
        Debug.LogError("LoadABPack...................................");
    }

}
