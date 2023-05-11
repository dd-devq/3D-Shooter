using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public event Action<int, int> OnHPChange;
    private int maxHP;
    public int curHP;

    public void SetupHP(int maxHP)
    {
        this.maxHP = maxHP;
        curHP = maxHP;
    }

    public void OnDamage(int damage)
    {
        curHP -= damage;
    }
}
