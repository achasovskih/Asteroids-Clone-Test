using System.Collections;
using UnityEngine;

public class EnemySpawner : EnemyModel
{
    [Header("Spawn points")]
    [SerializeField] private Transform[] _enemiesSpawnPoints;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] _spaceships;
    [SerializeField] private GameObject[] _asteroids;

    public override void StartEnemySpawn()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        while (true)
        {
            int spawnChance = Random.Range(0, 11);

            if (spawnChance < 7)
                Instantiate(_asteroids[Random.Range(0, _asteroids.Length)], _enemiesSpawnPoints[Random.Range(0, _enemiesSpawnPoints.Length)]);
            else
                Instantiate(_spaceships[Random.Range(0, _spaceships.Length)], _enemiesSpawnPoints[Random.Range(0, _enemiesSpawnPoints.Length)]);
            yield return new WaitForSeconds(Random.Range(0, 4));
        }
    }
}

public abstract class EnemyModel : MonoBehaviour
{
    public abstract void StartEnemySpawn();
}
