using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField] private InputManager inputManager;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private BloodBoy bloodBoy;

    [SerializeField] private Zombie zombiePrefab;
    [SerializeField] private Civilian civilianPrefab;
    [SerializeField] private Corpse corpsePrefab;
    
    public List<Zombie> zombies;
    public List<Civilian> civilians;
    public List<Corpse> corpses;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        bloodBoy.Initialize();
        cameraController.Initialize();

        zombies = new List<Zombie>(FindObjectsOfType<Zombie>());
        civilians = new List<Civilian>(FindObjectsOfType<Civilian>());
        corpses = new List<Corpse>(FindObjectsOfType<Corpse>());

        foreach (Zombie zombie in zombies)
        {
            zombie.Initialize();
        }
        
        foreach (Civilian civilian in civilians)
        {
            civilian.Initialize();
        }
    }

    public void CreateZombie(Corpse corpse)
    {
        corpses.Remove(corpse);
        Zombie newZombie = Instantiate(zombiePrefab, corpse.transform.position, Quaternion.identity);
        newZombie.Initialize();
        zombies.Add(newZombie);
    }

    public void CreateCorpse(Civilian civilian)
    {
        civilians.Remove(civilian);
        Corpse newCorpse = Instantiate(corpsePrefab, civilian.transform.position, Quaternion.identity);
        corpses.Add(newCorpse);
    }
    
    void Update()
    {
        inputManager.Refresh();
        cameraController.Refresh();
    }
}
