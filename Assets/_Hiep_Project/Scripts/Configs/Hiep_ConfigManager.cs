using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiep_ConfigManager : MonoBehaviour
{
    public static Hiep_ConfigManager Instance;
    public static Hiep_ConfigGun configGun;
    public static Hiep_ConfigEnemy configEnemy;
    public static Hiep_ConfigCharacter configCharacter;
    public static Hiep_ConfigMission configMission;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        //InitConfig(() =>
        //{
        //    Debug.Log("Load Config Done");
        //    // Init Database
        //    // Loading UI
        //});
    }

    public void InitConfig(Action callback)
    {
        StartCoroutine(LoopLoadConfig(callback));
    }

    IEnumerator LoopLoadConfig(Action callback)
    {
        yield return new WaitForSeconds(0.1f);

        configGun = Resources.Load("DataTable/Hiep_ConfigGun", typeof(ScriptableObject)) as Hiep_ConfigGun;
        yield return new WaitUntil(() => configGun != null);
        configEnemy = Resources.Load("DataTable/Hiep_ConfigEnemy", typeof(ScriptableObject)) as Hiep_ConfigEnemy;
        yield return new WaitUntil(() => configEnemy != null);
        configCharacter = Resources.Load("DataTable/Hiep_ConfigCharacter", typeof(ScriptableObject)) as Hiep_ConfigCharacter;
        yield return new WaitUntil(() => configCharacter != null);

        configMission = Resources.Load("DataTable/Hiep_ConfigMission", typeof(ScriptableObject)) as Hiep_ConfigMission;
        yield return new WaitUntil(() => configMission != null);

        if (callback != null)
        {
            callback();
        }
    }
}
