using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBoy : LifeForm
{
    public static BloodBoy instance;
    private float speed = 4;
    private float sprayRange = 2;

    public override void Initialize()
    {
        base.Initialize();
        instance = this;
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
                    corpse.AddJuice();
                    return;
                }
            }
        }
        
        //sprayin!!
    }
}
