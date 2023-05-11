using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hiep_ConfigMission : BYDataConfig<Hiep_ConfigMissionData>
{
    public override void AddKeySort()
    {
        OnAddKeySort(new ConfigComparePrimaryKey<Hiep_ConfigMissionData>("id"));
    }
}

[Serializable]
public class DataWave
{
    public int idEnemy;
    public float timeDelay;
}

[Serializable]
public class Hiep_ConfigMissionData
{
    public int id;
    public string sceneMap;
    [SerializeField]
    private string strDataWave;
    public List<DataWave> GetListWaves()
    {
        List<DataWave> lsWaves = new List<DataWave>();
        string[] waves = strDataWave.Split(';');
        foreach(string w in waves)
        {
            DataWave dataWave = new DataWave();
            string[] data = w.Split(':');
            dataWave.idEnemy = int.Parse(data[0]);
            dataWave.timeDelay = float.Parse(data[1]);

            lsWaves.Add(dataWave);
        }

        return lsWaves;
    }
}
