using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPrompt : MonoBehaviour
{

    [SerializeField] private GameObject extantTrigger;
    [SerializeField] private GameObject prompt;
    
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, BloodBoy.instance.transform.position);
        prompt.SetActive(dist < 1.9f);

        if (!extantTrigger.activeSelf)
        {
            Destroy(gameObject);
        }
    }
}
