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
        currentJuice -= 1;
        dripVfx.Play();
    }

    public float GetJuicePercentage()
    {
        return currentJuice / maxJuice;
    }

    public void Move(Vector3 direction)
    {
        agent.Move(direction * Time.deltaTime * speed);
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
