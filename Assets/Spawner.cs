using System.Collections;
using System.Collections.Generic;
using InternalAssets.Scripts.Application;
using InternalAssets.Scripts.GameScene;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int wallPoolSize = 5;
    [SerializeField] private float spawnRate;
    [SerializeField] private float wallMin;
    [SerializeField] private float wallMax;

    private List <Wall> walls;
    private int currentWall;

    private readonly Vector2 objectPoolPosition = new Vector2 (-15,0);
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;

    public bool continueSpawning;

    void Start()
    {
        continueSpawning = true;
        walls = new List<Wall>();
        for (var i = 0; i <= wallPoolSize; i++) 
            walls.Add(Instantiate(ApplicationManager.Instance.GameManager.GameSceneManager.WallPrefab, objectPoolPosition, Quaternion.identity));
        
        ApplicationManager.Instance.GameManager.GameStop += OnGameStopSpawning;
    }

    private void OnGameStopSpawning()
    {
        ApplicationManager.Instance.GameManager.GameStop -= OnGameStopSpawning;
        continueSpawning = false;
    }

    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (timeSinceLastSpawned >= spawnRate && continueSpawning)
        {
            timeSinceLastSpawned = 0f;
            float spawnYPosition = Random.Range(wallMin, wallMax);
            walls[currentWall].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentWall++;

            if (currentWall >= wallPoolSize) currentWall = 0;
        }
    }
}
