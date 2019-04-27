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

    public void TakeDamage(float dmg)
    {
        currentHp -= dmg;
        if (currentHp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isLiving = false;
        Debug.Log("Dead");
    }
      
}