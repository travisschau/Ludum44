using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : Unit
{
    protected override void Die()
    {
        base.Die();
        GameplayManager.instance.CreateCorpse(this);
        this.gameObject.SetActive(false);
    }
}
