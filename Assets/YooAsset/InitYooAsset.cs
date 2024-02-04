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


    //联机
    //private IEnumerator InitializeYooAsset()
    //{
    //    // 注意：GameQueryServices.cs 太空战机的脚本类，详细见StreamingAssetsHelper.cs
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
    //        Debug.Log("资源包初始化成功！");
    //    }
    //    else
    //    {
    //        Debug.LogError($"资源包初始化失败：{initOperation.Error}");
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
