using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Hiep;

public class BootLoaderManager : SingletonMono<BootLoaderManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.1f);
        Hiep_ConfigManager.Instance.InitConfig(() =>
        {
            UIManager.Instance.Init(() =>
            {
                PoolDefine.Instance.InitPool(() =>
                {
                    UIManager.Instance.ShowUI(UIIndex.UIMain);
                });

                RemoteConfigManager.Instance.Init((isComplete) =>
                {
                    string configVersion = RemoteConfigManager.Instance.GetStringValue("config_version", "");
                    Debug.Log("Config version: " + configVersion);
                });
            });
        });
    }
}
