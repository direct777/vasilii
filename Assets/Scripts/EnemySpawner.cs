using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyAI enemyPrefab;
    public PlayerController player;
    public List<Transform> patrolPoints;

    public int enemiesMaxCount = 5;
    public float delay = 3f;
    public float increaseEnemiesCountDelay = 10;
    private List<Transform> _spawnerPoints;
    private List<EnemyAI> _enemies;
    private float _timeLastSpawned;
    private void Start()
    {
        _spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        /*_spawnerPoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            _spawnerPoints.Add(child);
        }*/
        _enemies = new List<EnemyAI>();
        Invoke("IncreaseDifficulty", increaseEnemiesCountDelay);
    }
    private void CreateEnemy()
    {
        if (_enemies.Count >= enemiesMaxCount) return;
        if (Time.time - _timeLastSpawned < delay) return;
        //if (IsInvoking()) return;
        //Invoke("CreateEnemy", delay);
        var enemy = Instantiate(enemyPrefab);
        enemy.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
        enemy.player = player;
        enemy.patrolPoints = patrolPoints;
        _enemies.Add(enemy);
        _timeLastSpawned = Time.time;
    }
    private void CheckForDeadEnemies()
    {
        for (int i = 0; i < _enemies.Count; i++)
        {
            if (!(_enemies[i]).IsAlive())
            {
                _enemies.RemoveAt(i);
                i--;
            }
        }
    }
    private void IncreaseDifficulty()
    {
        enemiesMaxCount++;
        delay -= 0.1f;
        Invoke("IncreaseDifficulty", increaseEnemiesCountDelay);
    }
    private void Update()
    {
        CheckForDeadEnemies();        
        CreateEnemy();
    }
}
