using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hiep_ConfigCharacter : BYDataConfig<Hiep_ConfigCharacterData>
{
    public override void AddKeySort()
    {
        OnAddKeySort(new ConfigComparePrimaryKey<Hiep_ConfigCharacterData>("id"));
    }
}

[Serializable]
public class Hiep_ConfigCharacterData
{
    public int id;
    public string name;
    public int hp;
    public int skinID;
    public int weaponID;
    public string namePrefab;
}
