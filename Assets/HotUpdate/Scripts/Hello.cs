using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;
using UnityEngine;
using Component = UnityEngine.Component;

public class Hello
{
    public static void Run()
    {
        Debug.Log("Hello, HybridCLR");
        GameObject go = new GameObject("Test1");
        go.AddComponent<Print>();
        List<string> list = new List<string>();
        list.Add("Hello1");
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
            var print = gameObject.AddComponent<Print>();
            print.Conselose();
            Component[] components = gameObject.GetComponents<Component>();
            Debug.Log(components.Length);
            foreach (Component comp in components) 
            {
                Type componentType = comp.GetType();
                Debug.Log($"{comp.name}==={componentType.Name}");
                if (componentType.Name == "Print")
                {
                    //comp.SendMessage("Conselose", SendMessageOptions.DontRequireReceiver);//不可行
                    Debug.Log("================1111111111");
                    var co = gameObject.GetComponent(componentType);
                    var meth = componentType.GetMethod("Conselose");
                    //co.SendMessage(meth.Name);//不可行
                    meth.Invoke(co, null);
                    Debug.Log("-----------------------========="+meth.Name);

                    //var meths = componentType.GetMethods();
                    var meths = componentType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
                    Debug.Log(meths.Length);
                    foreach (var item in meths)
                    {
                        Debug.Log($"{item.Name}");
                    }

                }


            }

            Debug.LogWarning("PrintLoadAB.......End.......");
        }
    }

    public static async void TaskAsync()
    {
        for (int i = 0; i < 2; i++)
        {
            Debug.Log($"TaskAsync==>{i}");
            await Task.Delay(100);
        }
        PrintLoadAB();

    }


}