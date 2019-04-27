using UnityEngine;

public class Corpse : MonoBehaviour
{
    public void Reanimate()
    {
        GameplayManager.instance.CreateZombie(this);

    }
}