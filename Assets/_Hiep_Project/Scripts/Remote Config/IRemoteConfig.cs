using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IRemoteConfig 
{
    void Init(Dictionary<string, object> defaults, Action<bool> complete);
    string GetValueString(string key, string defaultValue);
    double GetValueDouble(string key, double defaultValue);
    long GetValueLong(string key, long defaultValue);
    bool GetValueBool(string key, bool defaultValue);
}
