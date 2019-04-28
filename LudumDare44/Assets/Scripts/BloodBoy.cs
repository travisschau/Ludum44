using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBoy : LifeForm
{
    public static BloodBoy instance;
    private float speed = 4;
    private float sprayRange = 2;

    public float maxJuice = 200;
    public float currentJuice;
    private float lastDrip;
    private float dripInterval = 1;
    private float dripAmount = 5;
    
    public ParticleSystem dripVfx;

    public override void Initialize()
    {
        base.Initialize();
        instance = this;
        currentJuice = maxJuice;
    }

    private void Update()
    {
        if (Time.time - lastDrip > dripInterval)
        {
            Drip();
            lastDrip = Time.time;
        }
    }

    private void Drip()
    {
        currentJuice -= dripAmount;
        dripVfx.Play();
    }

    public float GetJuicePercentage()
    {
        return currentJuice / maxJuice;
    }

    public void Move(Vector3 direction)
    {
//        agent.Move(direction * Time.deltaTime * speed);
        agent.SetDestination(transform.position + direction * 0.5f);
    }

    public void Cannibalize()
    {
        if (GameplayManager.instance.zombies.Count > 0)
        {
            Unit u = GetClosestEnemy(GameplayManager.instance.zombies);
            u.TakeDamage(Time.deltaTime * 100);
            currentJuice += Time.deltaTime * 50;

        }
    }
    
    Unit GetClosestEnemy (List<Unit> units)
    {
        Unit bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach(Unit u in units)
        {
            Vector3 directionToTarget = u.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if(dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = u;
            }
        }
     
        return bestTarget;
    }


    public void Spray()
    {
        foreach (Corpse corpse in GameplayManager.instance.corpses)
        {
            float dist = Vector3.Distance(transform.position, corpse.transform.position);
            {
                if (dist < sprayRange)
                {
                    float juiceSpray = 8 * Time.deltaTime;
                    currentJuice -= juiceSpray;
                    corpse.AddJuice(juiceSpray);
                    return;
                }
            }
        }
    }
}
