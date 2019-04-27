using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Unit
{
    private BloodBoy bloodBoy;

    public override void Initialize()
    {
        base.Initialize();
        bloodBoy = BloodBoy.instance;
    }
    
    void Update()
    {
        agent.SetDestination(bloodBoy.transform.position);
    }

}
