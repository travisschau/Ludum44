using UnityEngine;
using UnityEngine.AI;

public class Unit : LifeForm
{
    public float range = 2;
    public float dmg = 10;

    public void Attack(Unit target)
    {
        target.TakeDamage(dmg);
    }
}