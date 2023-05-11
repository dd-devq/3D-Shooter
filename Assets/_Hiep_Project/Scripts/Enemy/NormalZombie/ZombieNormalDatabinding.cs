using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNormalDatabinding : MonoBehaviour
{
    public Animator animator;

    private int Animkey_Attack;
    private int Animkey_Speed;
    private int Animkey_Dead;

    public float Speed
    {
        set
        {
            animator.SetFloat(Animkey_Speed, value);
        }
    }

    public bool Attack
    {
        set
        {
            animator.SetTrigger(Animkey_Attack);
        }
    }

    public bool Dead
    {
        set
        {
            animator.SetTrigger(Animkey_Dead);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Animkey_Speed = Animator.StringToHash("Speed");
        Animkey_Attack = Animator.StringToHash("Attack");
        Animkey_Dead = Animator.StringToHash("Dead");
    }
}
