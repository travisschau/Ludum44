using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Corpse : MonoBehaviour
{
    private float juiceValue;
    private float requiredJuice = 8;

    public Zombie zombiePrefab;

    [SerializeField] private HealthMeter meter;

    public void Initialize()
    {
        meter.Initialize(0);
        transform.localEulerAngles = Vector3.up * Random.Range(0, 360);
    }
    
    public void AddJuice(float juice)
    {
        juiceValue += juice;
        if (juiceValue > requiredJuice)
        {
            Reanimate();
        }
        meter.SetFill(juiceValue / requiredJuice);
    }

    private void Reanimate()
    {
        GameplayManager.instance.CreateZombie(this);
        this.gameObject.SetActive(false);
    }
}