using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : Unit
{
    public Zombie zombiePrefab;
    
    public override void Initialize()
    {
        base.Initialize();
        targetGroup = GameplayManager.instance.zombies;
        transform.eulerAngles = Vector3.up * Random.Range(0, 360);
    }

    protected override void Die()
    {
        base.Die();
        GameplayManager.instance.CreateCorpse(this);
        this.gameObject.SetActive(false);
    }
}
