using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieOnDamage : MonoBehaviour
{
    private ZombieSystem parent;

    private void Awake()
    {
        parent = GetComponent<ZombieSystem>();
    }

    public void ApplyDamage(int damage)
    {
        parent.OnDamage(damage);
    }
}
