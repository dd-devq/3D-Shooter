using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hiep_ConfigGun : BYDataConfig<Hiep_ConfigGunData>
{
    public override void AddKeySort()
    {
        OnAddKeySort(new ConfigComparePrimaryKey<Hiep_ConfigGunData>("id"));
    }
}

[Serializable]
public class Hiep_ConfigGunData
{
    public int id;
    public string name;
    public float rof;
    public int damage;
    public int clipSize;
    public int amountAmo;
    public float timeReload;
}