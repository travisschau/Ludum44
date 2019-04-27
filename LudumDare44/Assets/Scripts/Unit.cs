using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Unit : LifeForm
{
    public float dmg = 30;
    public float aggroRange = 4;
    public float attackRange = 1;

    public float attackCooldown = 0.3f;
    protected float lastAttack;

    public HealthMeter healthMeter;

    public override void Initialize()
    {
        healthMeter.Initialize();
        base.Initialize();
    }

    protected void Attack(LifeForm target)
    {
        if (Time.time - lastAttack > attackCooldown)
        {
            target.TakeDamage(dmg);
            lastAttack = Time.time;
        }
    }

    public override void TakeDamage(float dmgInflicted)
    {
        base.TakeDamage(dmgInflicted);
        healthMeter.SetFill(currentHp / maxHp);
    }

    private void Update()
    {
        healthMeter.transform.eulerAngles = Vector3.zero;
    }
}