using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiep_AutoHealth : MonoBehaviour
{
    public event Action<int, int> OnHPChange;

    private int maxHP;
    private int curHP;

    public void Setup(int maxHP)
    {
        this.maxHP = maxHP;
        curHP = maxHP;
    }

    public void OnDamage(int damage)
    {
        curHP -= damage;
        if (OnHPChange != null)
        {
            OnHPChange(curHP, maxHP);
        }

        if (curHP <= 0)
        {
            // Player Dead            
        }
    }
}
