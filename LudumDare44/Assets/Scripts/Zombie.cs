using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Zombie : Unit
{
    private const float minPullDist = 1;
    private const float maxPullDist = 8;
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
        float dist = Vector3.Distance(transform.position, BloodBoy.instance.transform.position);
        agent.SetDestination(BloodBoy.instance.transform.position);

        float pull = (dist - minPullDist) / (maxPullDist - minPullDist);
        float curSpeed = Mathf.Lerp(baseSpeed * 0.01f, baseSpeed * 2,
            (dist - minPullDist) / (maxPullDist - minPullDist));

        currentSpeed = curSpeed;
        agent.speed = currentSpeed;

    }
    
    protected override void Die()
    {
        base.Die();
        GameplayManager.instance.RemoveZombie(this);
        this.gameObject.SetActive(false);
    }

}