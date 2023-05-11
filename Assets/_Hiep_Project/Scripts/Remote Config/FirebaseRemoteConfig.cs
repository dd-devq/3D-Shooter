using System;
using System.Collections.Generic;
using Firebase.Extensions;
using System.Threading.Tasks;
using UnityEngine;

public class FirebaseRemoteConfig : IRemoteConfig
{
    private Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
    private Action<bool> complete;

    public bool GetValueBool(string key, bool defaultValue)
    {
        var value = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue(key);

        return value.BooleanValue;
    }

    public double GetValueDouble(string key, double defaultValue)
    {
        var value = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue(key);

        return value.DoubleValue;
    }

    public long GetValueLong(string key, long defaultValue)
    {
        var value = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue(key);

        return value.LongValue;
    }

    public string GetValueString(string key, string defaultValue)
    {
        var value = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.GetValue(key);
        if (string.IsNullOrEmpty(value.StringValue))
        {
            return defaultValue;
        }

        return value.StringValue;
    }

    public void Init(Dictionary<string, object> defaults, Action<bool> complete)
    {
        this.complete = complete;

        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;
            dependencyStatus = task.Result;
            if (dependencyStatus ==  Firebase.DependencyStatus.Available)
            {
                // Init Firebase Config
                InitializeFirebase(defaults);
            }
            else
            {
                Debug.LogError("Could not resolved all Firebase Dependence");
            }
        });
    }

    private void InitializeFirebase(Dictionary<string, object> defaults)
    {
        Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.SetDefaultsAsync(defaults);
        FetchDataAsync();
        ActiveCompelte(null, false);

    }

    public Task FetchDataAsync()
    {
        System.Threading.Tasks.Task fetchTask =
        Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
        return fetchTask.ContinueWithOnMainThread(FetchComplete);
    }

    private void FetchComplete(Task fetchTask)
    {
        var info = Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.Info;
        switch (info.LastFetchStatus)
        {
            case Firebase.RemoteConfig.LastFetchStatus.Success:
                Firebase.RemoteConfig.FirebaseRemoteConfig.DefaultInstance.ActivateAsync()
                    .ContinueWithOnMainThread((activeTask) => ActiveCompelte(activeTask, true));
                break;

            default:
                break;
        }
    }

    private void ActiveCompelte(Task activeTask, bool isOnline)
    {
        if (!isOnline || activeTask.IsCompleted)
        {
            complete(isOnline);
        }
    }
}
