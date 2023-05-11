using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hiep_ConfigEnemy : BYDataConfig<Hiep_ConfigEnemyData>
{
    public override void AddKeySort()
    {
        OnAddKeySort(new ConfigComparePrimaryKey<Hiep_ConfigEnemyData>("id"));
    }
}

[Serializable]
public class Hiep_ConfigEnemyData
{
    public int id;
    public string name;
    public int hp;
    public int damage;
    public float speed;
    public float rof;
    public string namePrefab;
}