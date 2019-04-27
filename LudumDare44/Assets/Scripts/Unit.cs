using System.Collections.Generic;
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

    protected List<Unit> targetGroup;

    public HealthMeter healthMeter;
    
    private LifeForm target;
    private bool hasTarget;

    protected float baseSpeed;
    protected float currentSpeed;

    public override void Initialize()
    {
        healthMeter.Initialize();
        base.Initialize();
        
        baseSpeed = agent.speed;
        currentSpeed = baseSpeed;
    }
    
    protected virtual void DefaultMovement()
    {
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

    
    void Update()
    {
        if (targetGroup == null) return;
        if (hasTarget)
        {
            if (target.isLiving)
            {
                EvaluateFocus();
                return;                
            }

            hasTarget = false;
            target = null;
        }

        if (AnyTargetInAggroRange()) return;
        
        DefaultMovement();
    }

    private void EvaluateFocus()
    {
        if (AnyTargetInAttackRange()) return;

        float dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist < aggroRange)
        {
            agent.SetDestination(target.transform.position); 
            currentSpeed = baseSpeed * 2;
        }
        else
        {
            hasTarget = false;
        }
    }

    private bool AnyTargetInAggroRange()
    {
        foreach (Unit u in targetGroup)
        {
            if (!u.isLiving) continue;
            float dist = Vector3.Distance(transform.position, u.transform.position);
            if (dist < aggroRange)
            {
                hasTarget = true;
                target = u;
                return true;
            }
        }
        return false;
    }

    private bool AnyTargetInAttackRange()
    {
        foreach (Unit u in targetGroup)
        {
            if (!u.isLiving) continue;

            float dist = Vector3.Distance(transform.position, u.transform.position);
            
            if (dist < attackRange)
            {
                agent.ResetPath();
                hasTarget = true;
                target = u;
                Attack(u);
                if (u.currentHp <= 0)
                {
                    hasTarget = false;
                    target = null;
                }
                return true;
            }
        }

        return false;
    }
}