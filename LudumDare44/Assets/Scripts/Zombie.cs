using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Unit
{
    private LifeForm target;
    private bool hasTarget;

    private float baseSpeed;
    private float currentSpeed;

    public override void Initialize()
    {
        base.Initialize();

        baseSpeed = agent.speed;
        currentSpeed = baseSpeed;

        aggroRange = 6;
    }

    void Update()
    {
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
        
        agent.SetDestination(BloodBoy.instance.transform.position);
        currentSpeed = baseSpeed;

    }

    private void EvaluateFocus()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);

        if (AnyTargetInAttackRange()) return;

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
        foreach (Civilian civilian in GameplayManager.instance.civilians)
        {
            if (!civilian.isLiving) continue;
            float dist = Vector3.Distance(transform.position, civilian.transform.position);
            if (dist < aggroRange)
            {
                hasTarget = true;
                target = civilian;
                return true;
            }
        }
        return false;
    }

    private bool AnyTargetInAttackRange()
    {
        foreach (Civilian civilian in GameplayManager.instance.civilians)
        {
            if (!civilian.isLiving) continue;

            float dist = Vector3.Distance(transform.position, civilian.transform.position);
            if (dist < attackRange)
            {
                hasTarget = true;
                target = civilian;
                Attack(civilian);
                if (civilian.currentHp <= 0)
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
