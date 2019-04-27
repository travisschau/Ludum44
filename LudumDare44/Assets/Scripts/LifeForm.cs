using UnityEngine;
using UnityEngine.AI;

public class LifeForm : MonoBehaviour
{
    protected NavMeshAgent agent;
    public float maxHp = 100;
    public float currentHp;
    private bool isEnemy;
    
    public virtual void Initialize()
    {
        currentHp = maxHp;
        agent = GetComponent<NavMeshAgent>();
    }

    protected void TakeDamage(float dmg)
    {
        currentHp -= dmg;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        
    }
      
}