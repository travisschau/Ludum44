using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Unit : LifeForm
{
    public float dmg = 100;
    public float aggroRange = 4;
    public float attackRange = 1;

    public HealthMeter healthMeter;

    public override void Initialize()
    {
        healthMeter.Initialize();
        base.Initialize();
    }

    protected void Attack(LifeForm target)
    {
        target.TakeDamage(dmg);
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