using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YooAsset;

public class InitYooAsset : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        YooAssets.Initialize();

       
    }


    //����
    //private IEnumerator InitializeYooAsset()
    //{
    //    // ע�⣺GameQueryServices.cs ̫��ս���Ľű��࣬��ϸ��StreamingAssetsHelper.cs
    //    string defaultHostServer = "http://127.0.0.1/CDN/Android/v1.0";
    //    string fallbackHostServer = "http://127.0.0.1/CDN/Android/v1.0";
    //    var initParameters = new HostPlayModeParameters();
    //    initParameters.BuildinQueryServices = new GameQueryServices();
    //    initParameters.DecryptionServices = new FileOffsetDecryption();
    //    initParameters.RemoteServices = new RemoteServices(defaultHostServer, fallbackHostServer);
    //    var initOperation = package.InitializeAsync(initParameters);
    //    yield return initOperation;

    //    if (initOperation.Status == EOperationStatus.Succeed)
    //    {
    //        Debug.Log("��Դ����ʼ���ɹ���");
    //    }
    //    else
    //    {
    //        Debug.LogError($"��Դ����ʼ��ʧ�ܣ�{initOperation.Error}");
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
