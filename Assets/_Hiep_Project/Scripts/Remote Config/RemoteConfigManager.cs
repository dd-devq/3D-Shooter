using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;

public class RemoteConfigManager : Singleton<RemoteConfigManager>
{
    private IRemoteConfig remoteConfig;
    private Dictionary<string, object> defaults = new Dictionary<string, object>();

    private Dictionary<string, JSONNode> configValues = new Dictionary<string, JSONNode>();


    public void Init(Action<bool> Complete)
    {
        remoteConfig = new FirebaseRemoteConfig();
        remoteConfig.Init(defaults, (isCompleted) =>
        {
            Complete(isCompleted);
            Debug.Log("Complete Init Firebase Config");
        });
    }

    public string GetStringValue(string key, string value)
    {
        return remoteConfig.GetValueString(key, value);
    }

    public double GetDoubleValue(string key, double value)
    {
        return remoteConfig.GetValueDouble(key, value);
    }

    public long GetLongValue(string key, long value)
    {
        return remoteConfig.GetValueLong(key, value);
    }

    public bool GetBoolValue(string key, bool value)
    {
        return remoteConfig.GetValueBool(key, value);
    }
}
