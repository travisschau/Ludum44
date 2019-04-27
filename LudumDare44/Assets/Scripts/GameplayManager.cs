using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField] private InputManager inputManager;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private BloodBoy bloodBoy;

    [SerializeField] private Zombie zombiePrefab;
    [SerializeField] private Civilian civilianPrefab;
    [SerializeField] private Corpse corpsePrefab;
    
    private List<Zombie> _zombies;
    private List<Civilian> _civilians;
    public List<Corpse> corpses;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        bloodBoy.Initialize();
        cameraController.Initialize();

        _zombies = new List<Zombie>(FindObjectsOfType<Zombie>());
        _civilians = new List<Civilian>(FindObjectsOfType<Civilian>());
        corpses = new List<Corpse>(FindObjectsOfType<Corpse>());

        foreach (Zombie zombie in _zombies)
        {
            zombie.Initialize();
        }
        
        foreach (Civilian civilian in _civilians)
        {
            civilian.Initialize();
        }
    }

    public void CreateZombie(Corpse corpse)
    {
        corpses.Remove(corpse);
        Zombie newZombie = Instantiate(zombiePrefab, corpse.transform.position, Quaternion.identity);
        _zombies.Add(newZombie);
        
    }

    void Update()
    {
        inputManager.Refresh();
        cameraController.Refresh();
    }
}
