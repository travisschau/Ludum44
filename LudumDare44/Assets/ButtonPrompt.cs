using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrompt : MonoBehaviour
{

    [SerializeField] private GameObject extantTrigger;
    
    // Update is called once per frame
    void Update()
    {
        if (!extantTrigger.activeSelf)
        {
            Destroy(gameObject);
        }
    }
}
