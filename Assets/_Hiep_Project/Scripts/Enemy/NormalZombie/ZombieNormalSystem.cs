using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieNormalSystem : ZombieSystem
{
    public ZombieNormal_IdleState idleState;
    public ZombieNormal_RunState runState;
    public ZombieNormal_AttackState attackState;
    public ZombieNormal_DeadState deadState;

    public NavMeshAgent agent;
    public float radiousAttack = 2;
    public Transform target;

    public ZombieHealth zombieHealth;
    public ZombieNormalDatabinding zombieNormalDatabinding;
    public Hiep_ConfigEnemyData configEnemyData;

    private void Awake()
    {
        zombieHealth = GetComponent<ZombieHealth>();
        zombieNormalDatabinding = GetComponent<ZombieNormalDatabinding>();
    }

    public override void OnSystemStart()
    {
        base.OnSystemStart();
       
        idleState.parent = this;
        AddState(idleState);

        runState.parent = this;
        AddState(runState);

        attackState.parent = this;
        AddState(attackState);

        deadState.parent = this;
        AddState(deadState);
        
    }

    public override void OnSetupZombie(object dataInit)
    {
        base.OnSetupZombie(dataInit);
        configEnemyData = (Hiep_ConfigEnemyData)dataInit;
       
        target = GameObject.FindWithTag("Player").transform;        
        agent.speed = configEnemyData.speed;
        zombieHealth.SetupHP(configEnemyData.hp);
        damage = configEnemyData.damage;


        //GotoState(idleState);
    }

    public override void OnDamage(int damage)
    {        
        base.OnDamage(damage);
        zombieHealth.OnDamage(damage);
        if (zombieHealth.curHP <= 0)
        {
            GotoState(deadState);
        }


    }

}
