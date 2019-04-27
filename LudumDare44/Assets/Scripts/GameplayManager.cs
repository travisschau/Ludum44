using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField] private Hud hud;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private BloodBoy bloodBoy;

    [SerializeField] private Zombie zombiePrefab;
    public Civilian civilianPrefab;
    [SerializeField] private Corpse corpsePrefab;
    
    public List<Unit> zombies;
    public List<Unit> civilians;
    public List<Corpse> corpses;
    public List<CivilianSpawner> civilianSpawners;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        hud.Initialize();
        bloodBoy.Initialize();
        cameraController.Initialize();

        zombies = new List<Unit>(FindObjectsOfType<Zombie>());
        civilians = new List<Unit>(FindObjectsOfType<Civilian>());
        corpses = new List<Corpse>(FindObjectsOfType<Corpse>());
        civilianSpawners = new List<CivilianSpawner>(FindObjectsOfType<CivilianSpawner>());

        foreach (Zombie zombie in zombies)
        {
            zombie.Initialize();
        }
        
        foreach (Civilian civilian in civilians)
        {
            civilian.Initialize();
        }
        
        foreach (Corpse c in corpses)
        {
            c.Initialize();
        }

        foreach (CivilianSpawner c in civilianSpawners)
        {
            c.Initialize();
        }

    }

    public void CreateZombie(Corpse corpse)
    {
        corpses.Remove(corpse);
        Zombie newZombie = Instantiate(corpse.zombiePrefab, corpse.transform.position, Quaternion.identity);
        newZombie.Initialize();
        zombies.Add(newZombie);
    }

    public void CreateCorpse(Civilian civilian)
    {
        civilians.Remove(civilian);
        Corpse newCorpse = Instantiate(corpsePrefab, civilian.transform.position, Quaternion.identity);
        newCorpse.zombiePrefab = civilian.zombiePrefab;
        newCorpse.Initialize();
        corpses.Add(newCorpse);
    }

    public void RemoveZombie(Zombie z)
    {
        zombies.Remove(z);
    }
    
    
    public void CreateCivilian(CivilianSpawner spawner)
    {
        Vector3 spawnLocation = spawner.transform.position;
        spawnLocation += Vector3.forward * Random.Range(-2, 2);
        spawnLocation += Vector3.right * Random.Range(-2, 2);

        Civilian newCivilian = Instantiate(civilianPrefab, spawnLocation, Quaternion.identity);
        newCivilian.Initialize();
        civilians.Add(newCivilian);
    }
    
    void Update()
    {
        inputManager.Refresh();
        cameraController.Refresh();
        hud.Refresh();
    }

}
