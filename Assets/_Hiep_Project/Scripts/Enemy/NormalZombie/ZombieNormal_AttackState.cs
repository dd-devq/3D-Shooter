using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ZombieNormal_AttackState : FSMState
{
    [NonSerialized]
    public ZombieNormalSystem parent;

    private float timer = 0;
    private float timeLimit = 1;

    public override void OnEnter()
    {
        Debug.Log("Attack");
        base.OnEnter();
        // Anim Attack
        parent.zombieNormalDatabinding.Attack = true;
        timer = 0;
    }

    public override void OnUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= timeLimit)
        {
            // Apply damage for Character
            parent.GotoState(parent.idleState);
        }
            base.OnUpdate();
    }

    public override void OnExit()
    {
        timer = 0;
        base.OnExit();
    }

}
