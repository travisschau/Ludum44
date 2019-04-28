using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager instance;

    [SerializeField] private SlideShow slideShow;
    [SerializeField] private Hud hud;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private BloodBoy bloodBoy;
    [SerializeField] private GameOverDialog gameOverDialog;

    [SerializeField] private Zombie zombiePrefab;
    public Civilian civilianPrefab;
    [SerializeField] private Corpse corpsePrefab;
    [SerializeField] private ParticleSystem civilianDeathVfxPrefab;
    [SerializeField] private ParticleSystem zombieDeathVfxPrefab;
    
    public List<Unit> zombies;
    public List<Unit> civilians;
    public List<Corpse> corpses;
    public List<CivilianSpawner> civilianSpawners;

    public int largestArmy;
    public int totalZombies;

    public bool isPreGame = true;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
        slideShow.Initialize();
        hud.Initialize();
        bloodBoy.Initialize();
        cameraController.Initialize();
        gameOverDialog.Initialize();

        zombies = new List<Unit>(FindObjectsOfType<Zombie>());
        civilians = new List<Unit>(FindObjectsOfType<Civilian>());
        corpses = new List<Corpse>(FindObjectsOfType<Corpse>());
        civilianSpawners = new List<CivilianSpawner>(FindObjectsOfType<CivilianSpawner>());

        foreach (Unit u in zombies)
        {
            u.Initialize();
        }
        
        foreach (Unit u in civilians)
        {
            u.Initialize();
        }
        
        foreach (Corpse c in corpses)
        {
            c.Initialize();
        }

        foreach (CivilianSpawner c in civilianSpawners)
        {
            c.Initialize();
        }

        slideShow.Show();
    }

    public void EndSlideShow()
    {
        isPreGame = false;
        hud.Show();
    }

    public void EvaluateGameOver()
    {
        if (BloodBoy.instance.currentJuice <= 0 || (zombies.Count == 0 && corpses.Count == 0))
        {
            GameOver();
        }
    }

    public void CreateZombie(Corpse corpse)
    {
        corpses.Remove(corpse);
        Zombie newZombie = Instantiate(corpse.zombiePrefab, corpse.transform.position, Quaternion.identity);
        newZombie.Initialize();
        zombies.Add(newZombie);

        totalZombies++;
        if (zombies.Count > largestArmy)
        {
            largestArmy = zombies.Count;
        }
    }

    public void CreateCorpse(Civilian civilian)
    {
        ParticleSystem deathVfx = Instantiate(civilianDeathVfxPrefab, civilian.transform.position, Quaternion.identity);
        deathVfx.Play();
        
        civilians.Remove(civilian);
        Corpse newCorpse = Instantiate(corpsePrefab, civilian.transform.position, Quaternion.identity);
        newCorpse.zombiePrefab = civilian.zombiePrefab;
        newCorpse.Initialize();
        corpses.Add(newCorpse);
    }

    public void RemoveZombie(Zombie z)
    {
        ParticleSystem deathVfx = Instantiate(zombieDeathVfxPrefab, z.transform.position, Quaternion.identity);
        deathVfx.Play();

        zombies.Remove(z);
    }

    public void GameOver()
    {
        isPreGame = true;
        gameOverDialog.Show();
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
        if (isPreGame) return;
        inputManager.Refresh();
        cameraController.Refresh();
        hud.Refresh();
        bloodBoy.Refresh();
    }

}
