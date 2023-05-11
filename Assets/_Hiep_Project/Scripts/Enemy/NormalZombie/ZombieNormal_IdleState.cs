using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

[Serializable]
public class ZombieNormal_IdleState : FSMState
{
    //[NonSerialized]
    public ZombieNormalSystem parent;
    private float timeWait = 0;
    private float randomTime = 2;

    public override void OnEnter()
    {
        Debug.Log("Idle");
        base.OnEnter();
        randomTime = Random.Range(2f, 4f);
        timeWait = 0;
        // Set anim idle    
        parent.zombieNormalDatabinding.Speed = 0;
        parent.agent.speed = 0;
    }


    public override void OnUpdate()
    {
        timeWait += Time.deltaTime;
        if (timeWait >= randomTime)
        {
            parent.GotoState(parent.runState, parent.target);
        }
        base.OnUpdate();
    }

    public override void OnExit()
    {
        timeWait = 0;
        base.OnExit();
    }
}
