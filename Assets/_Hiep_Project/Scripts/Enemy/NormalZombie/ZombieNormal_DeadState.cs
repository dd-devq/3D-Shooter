using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ZombieNormal_DeadState : FSMState
{
    [NonSerialized]
    public ZombieNormalSystem parent;

    private float timer;
    public override void OnEnter()
    {
        Debug.Log("Dead");
        base.OnEnter();
        parent.zombieNormalDatabinding.Dead = true;
        timer = 1;
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {            
            parent.OnDead();
        }
        base.OnUpdate();
    }
}
