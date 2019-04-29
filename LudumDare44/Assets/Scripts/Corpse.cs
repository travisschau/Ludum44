using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Corpse : MonoBehaviour
{
    private float juiceValue;
    private float requiredJuice = 8;

    [SerializeField] private GameObject raiseAlert;
    [SerializeField] private Image raiseAlertIcon;
    
    public Zombie zombiePrefab;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip raiseSfx;
    
    [SerializeField] private HealthMeter meter;

    private bool hasTriggered = false;

    public void Initialize()
    {
        meter.Initialize(0);
        transform.localEulerAngles = Vector3.up * Random.Range(0, 360);
    }

    public void Update()
    {
        raiseAlert.transform.eulerAngles = Vector3.zero;
        raiseAlert.SetActive(!meter.isVisible);
    }
    
    public void AddJuice(float juice)
    {
        juiceValue += juice;
        if (juiceValue > requiredJuice && !hasTriggered)
        {
            hasTriggered = true;
            Reanimate();
        }
        meter.SetFill(juiceValue / requiredJuice);
    }

    private void Reanimate()
    {
        AudioManager.instance.PlaySfxClip(raiseSfx);
        GameplayManager.instance.CreateZombie(this);
        this.gameObject.SetActive(false);
    }
}