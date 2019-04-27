using UnityEngine;

public class Corpse : MonoBehaviour
{
    private float juiceValue;
    private float requiredJuice = 100;

    [SerializeField] private HealthMeter meter;

    public void Initialize()
    {
        meter.Initialize();
        meter.SetFill(0);
    }
    
    public void AddJuice()
    {
        juiceValue += 100 * Time.deltaTime;
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