using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiep_FirebaseAnalyticManager : SingletonMono<Hiep_FirebaseAnalyticManager>
{
    public void LogEvent(string nameEvent, Firebase.Analytics.Parameter[] parameters)
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent(nameEvent, parameters);
    }

    public void LogEvent(string nameEvent)
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent(nameEvent);
    }

    public void LogEvent(string nameEvent, string parameterKey, string parameterValue)
    {
        Firebase.Analytics.FirebaseAnalytics.LogEvent(nameEvent, parameterKey, parameterValue);
    }
}
