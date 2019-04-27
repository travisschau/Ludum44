using UnityEngine;

public class Corpse : MonoBehaviour
{
    private float juiceValue;
    private float requiredJuice = 4;

    [SerializeField] private HealthMeter meter;

    public void Initialize()
    {
        meter.Initialize(0);
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