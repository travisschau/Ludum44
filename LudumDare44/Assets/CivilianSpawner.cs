using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilianSpawner : MonoBehaviour
{
    private const float MinDist = 20;
    private const float MaxDist = 60;

    private const float MinSpawn = 1;
    private const float MaxSpawn = 10;

    public void Initialize()
    {
        float distFromOrigin = Vector3.Distance(Vector3.zero, transform.position);
        distFromOrigin = Mathf.Clamp(distFromOrigin, MinDist, MaxDist) - MinDist;
//        Debug.Log("dist from origin: " + distFromOrigin);
        
        float relativeDist = MaxDist - MinDist - distFromOrigin;
        relativeDist = 1 - (relativeDist / (MaxDist - MinDist));
//        Debug.Log("relativeDist: " + relativeDist);

        int spawnCount = Mathf.FloorToInt(Mathf.Lerp(MinSpawn, MaxSpawn, relativeDist));
//        Debug.Log(relativeDist + " so we spawn " + spawnCount);

        for (int i = 0; i < spawnCount; i++)
        {
            GameplayManager.instance.CreateCivilian(this);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 3);
    }

}
