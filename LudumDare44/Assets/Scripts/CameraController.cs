using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float minFov = 30;
    private float maxFov = 60;
    private float maxArmy = 8;
    public void Initialize()
    {
        
    }

    public void Refresh()
    {
        transform.position = BloodBoy.instance.transform.position;
        float armySize = GameplayManager.instance.zombies.Count / maxArmy;
        
        float newFov = Mathf.Lerp(minFov, maxFov, armySize);
        
        Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, newFov, Time.deltaTime);
    }
}