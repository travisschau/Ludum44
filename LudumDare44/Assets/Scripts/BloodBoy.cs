using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodBoy : LifeForm
{
    public static BloodBoy instance;
    private float speed = 4;

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
        //sprayin!!
    }
}
