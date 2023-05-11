using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSystem : FSMSystem
{
    public event Action<ZombieSystem> OnZombieDead;
    
    public int damage;

    public virtual void OnSetupZombie(object dataInit)
    {

    }

    public virtual void OnDamage(int damage)
    {

    }

    public void OnDead()
    {
        if (OnZombieDead != null)
        {
            OnZombieDead(this);
        }
        Destroy(gameObject);
    }
}
