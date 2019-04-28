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
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Refresh()
    {
        healthMeter.fillAmount = BloodBoy.instance.GetJuicePercentage();
        counterHud.text = GameplayManager.instance.totalZombies.ToString();
    }
}
