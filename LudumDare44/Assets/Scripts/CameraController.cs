using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public void Initialize()
    {
        
    }

    public void Refresh()
    {
        transform.position = BloodBoy.instance.transform.position;
    }
}
