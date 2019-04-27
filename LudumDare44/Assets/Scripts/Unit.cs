using UnityEngine;
using UnityEngine.AI;

public class Unit : LifeForm
{
    public float dmg = 100;
    public float aggroRange = 4;
    public float attackRange = 1;

    public void Attack(LifeForm target)
    {
        target.TakeDamage(dmg);
    }
}