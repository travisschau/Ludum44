using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    [SerializeField] private Image healthMeter;
    [SerializeField] private TextMeshProUGUI counterHud;
    
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
