using UnityEngine;

public class Corpse : MonoBehaviour
{
    public float juiceValue;
    public float requiredJuice = 100;

    public void AddJuice()
    {
        juiceValue += 100 * Time.deltaTime;
        if (juiceValue > requiredJuice)
        {
            Reanimate();
        }
    }
    public void Reanimate()
    {
        GameplayManager.instance.CreateZombie(this);
        this.gameObject.SetActive(false);
    }
}