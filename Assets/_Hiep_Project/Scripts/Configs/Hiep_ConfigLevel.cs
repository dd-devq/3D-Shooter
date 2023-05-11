using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Hiep_ConfigLevel", menuName = "Config/Hiep_ConfigLevel", order = 0)]
public class Hiep_ConfigLevel : ScriptableObject
{
    public int numberLevelPerPage = 12;
    public Hiep_ConfigLevelData[] data;
    
    static Hiep_ConfigLevel Instance;
    public static Hiep_ConfigLevelData GetConfigLevel(int id)
    {
        Instance = Resources.Load<Hiep_ConfigLevel>("Hiep_Config/Hiep_ConfigLevel");
        Hiep_ConfigLevelData configLevelData = null;
        foreach(Hiep_ConfigLevelData config in Instance.data)
        {
            if (config.id == id)
            {
                configLevelData = config;
                break;
            }
        }

        if( configLevelData == null)
        {
            configLevelData = Instance.data[0];
        }

        return configLevelData;
    }

    public static int GetNumberLevelPerPage()
    {
        Instance = Resources.Load<Hiep_ConfigLevel>("Hiep_Config/Hiep_ConfigLevel");
        return Instance.numberLevelPerPage;
    }

    public static int GetTotalCountConfig()
    {
        Instance = Resources.Load<Hiep_ConfigLevel>("Hiep_Config/Hiep_ConfigLevel");
        return Instance.data.Length;
    }
}

[Serializable]
public class Hiep_ConfigLevelData
{
    public int id;
    public bool isUnlock;
    public int numberStar;
    public bool isChest;
}
