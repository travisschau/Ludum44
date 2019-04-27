using UnityEngine;
using UnityEngine.AI;

public class LifeForm : MonoBehaviour
{
    protected NavMeshAgent agent;
    public float maxHp = 100;
    public float currentHp;
    private bool isEnemy;
    public bool isLiving;
    
    public virtual void Initialize()
    {
        isLiving = true;
        currentHp = maxHp;
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual void TakeDamage(float dmgInflicted)
    {
        currentHp -= dmgInflicted;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        isLiving = false;
    }
      
}