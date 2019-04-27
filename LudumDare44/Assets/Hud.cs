using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private Image healthMeter;
    
    // Start is called before the first frame update
    public void Initialize()
    {
        healthMeter.fillAmount = 1;
    }

    public void Refresh()
    {
        healthMeter.fillAmount = BloodBoy.instance.GetJuicePercentage();
    }
}
