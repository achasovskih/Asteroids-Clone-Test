using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  ласс-фабрика, отвечающий за порождение врагов
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn points")]
    [SerializeField] private Transform[] _enemiesSpawnPoints;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] _spaceships;
    [SerializeField] private GameObject[] _asteroids;

    private List<BaseEnemy> _spawnedEnemies;

    public GameScreenController GameScreenController;
    public GameObject Player;

    public void StartEnemySpawn()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        _spawnedEnemies = new();

        while (true)
        {
            int spawnChance = Random.Range(0, 11);

            if (spawnChance < 7)
                _spawnedEnemies.Add(CreateEnemy(_asteroids, new Asteroid()));

            else
                _spawnedEnemies.Add(CreateEnemy(_spaceships, new Spaceship()));

            yield return new WaitForSeconds(Random.Range(2, 7));
        }
    }

    private BaseEnemy CreateEnemy(GameObject[] pool, BaseEnemy enemyType)
    {
        enemyType = Instantiate(pool[Random.Range(0, pool.Length)],
            _enemiesSpawnPoints[Random.Range(0, _enemiesSpawnPoints.Length)]).GetComponent<BaseEnemy>();
        enemyType.player = Player;
        enemyType.GameScreenController = GameScreenController;
        return enemyType;
    }
}
