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
        print("��ʼ");
        await TestRun();
        print("����");

    }

    private async Task<int> TestRun()
    {
        for (int i = 0; i < 100; i++)
        {
            //Debug.Log(Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(100);
            txtNum.text = $"{Thread.CurrentThread.ManagedThreadId}==={i}";
        }
            print("��ʼ����");
        return -1;
    }
}
