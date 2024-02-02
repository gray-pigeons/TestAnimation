using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Hello
{
    public static void Run()
    {
        Debug.Log("Hello, HybridCLR");
        Debug.LogError("Hello World!!!");
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
        }
        Debug.Log("okokoko");
        GameObject go = new GameObject("Test1");
        go.AddComponent<Print>();
        List<string> list = new List<string>();
        list.Add("Hello1");
        list.Add("Hello2");
        list.Add("Hello3");
        list.Add("Hello4");
        list.Add("Hello5");
        foreach (string s in list)
        {
            Debug.Log($"Hello {s}");
        }
        TaskAsync();


    }

    private static void PrintLoadAB()
    {
       Debug.LogWarning("PrintLoadAB.........start.....");
       GameObject gameObject =  GameObject.FindGameObjectWithTag("AB");
        if (gameObject != null )
        {
            Debug.Log(gameObject.name);
            //Type type = gameObject.GetType();
            //Debug.Log(type.Name);
            //type.GetMethod("LoadABPackage")?.Invoke(null,null);
            //var me = type.GetMethod("Print");
            //Debug.Log(me.Name);
            //me.Invoke(null,null);
            var print = gameObject.AddComponent<Print>();
            print.Conselose();
            Debug.Log("PrintLoadAB..............");
        }
    }

    public static async void TaskAsync()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"TaskAsync==>{i}");
            await Task.Delay(100);
        }
        PrintLoadAB();

    }


}