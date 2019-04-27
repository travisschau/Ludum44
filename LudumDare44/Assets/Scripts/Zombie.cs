using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Zombie : Unit
{
    public override void Initialize()
    {
        base.Initialize();

        aggroRange = 6;
        targetGroup = GameplayManager.instance.civilians;
        TweenAlive();
    }

    private void TweenAlive()
    {
        transform.localScale = new Vector3(1, 0.4f, 1);
        transform.DOScaleY(1, 0.3f).SetEase(Ease.OutBack);
    }

    protected override void DefaultMovement()
    {
        agent.SetDestination(BloodBoy.instance.transform.position);
        currentSpeed = baseSpeed;
    }
    
    protected override void Die()
    {
        base.Die();
        GameplayManager.instance.RemoveZombie(this);
        this.gameObject.SetActive(false);
    }

}