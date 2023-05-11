using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiep_AutoDatabinding : MonoBehaviour
{
    private Animator animator;
    private int Animkey_Speed;
    private int Animkey_Attack;
    
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
            if (value)
            {
                animator.SetTrigger(Animkey_Attack);
            }
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        Animkey_Speed = Animator.StringToHash("Speed");
        Animkey_Attack = Animator.StringToHash("Attack");
    }
}
