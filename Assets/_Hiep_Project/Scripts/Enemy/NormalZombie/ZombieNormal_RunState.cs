using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ZombieNormal_RunState : FSMState
{
    [NonSerialized]
    public ZombieNormalSystem parent;
    private Transform target;
    public override void OnEnter(object data)
    {
        Debug.Log("Run");
        target = (Transform)data;
        // Play animtion run
        parent.agent.stoppingDistance = parent.radiousAttack;
        parent.agent.speed = parent.configEnemyData.speed;
        parent.zombieNormalDatabinding.Speed = parent.agent.speed;
        
        base.OnEnter(data);
    }
    
    public override void OnUpdate()
    {
        parent.agent.SetDestination(target.position);
        if (Vector3.Distance(parent.transform.position, target.position) <= parent.radiousAttack)
        {
            parent.GotoState(parent.attackState);
        }
        base.OnUpdate();
    }
}
