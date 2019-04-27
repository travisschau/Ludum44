using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Unit
{
    private BloodBoy bloodBoy;

    private LifeForm target;
    private bool hasTarget;

    public override void Initialize()
    {
        base.Initialize();
        bloodBoy = BloodBoy.instance;
    }

    void Update()
    {
        Debug.Log(hasTarget);
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
        
        agent.SetDestination(bloodBoy.transform.position);            
        
    }

    private void EvaluateFocus()
    {
        float dist = Vector3.Distance(transform.position, target.transform.position);

        if (AnyTargetInAttackRange()) return;

        if (dist < aggroRange)
        {
            agent.SetDestination(target.transform.position);                        
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
