using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TestTask : MonoBehaviour
{
    [SerializeField] Text txtNum;
    async void Start()
    {
        print("开始");
        await TestRun();
        print("结束");

    }

    private async Task<int> TestRun()
    {
        for (int i = 0; i < 100; i++)
        {
            //Debug.Log(Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(100);
            txtNum.text = $"{Thread.CurrentThread.ManagedThreadId}==={i}";
        }
            print("开始返回");
        return -1;
    }
}
