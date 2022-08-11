using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn points")]
    [SerializeField] private Transform[] _enemiesSpawnPoints;

    [Header("Prefabs")]
    [SerializeField] private GameObject[] _spaceships;
    [SerializeField] private GameObject[] _asteroids;

    public GameObject player;

    public void StartEnemySpawn()
    {
        StartCoroutine(EnemySpawnCoroutine());
    }

    private IEnumerator EnemySpawnCoroutine()
    {
        while (true)
        {
            int spawnChance = Random.Range(0, 11);

            if (spawnChance < 7)
                CreateEnemy(_asteroids, new Asteroid());

            else
                CreateEnemy(_spaceships, new Spaceship());

            yield return new WaitForSeconds(Random.Range(0, 4));
        }
    }

    private void CreateEnemy(GameObject[] pool, BaseEnemy enemyType)
    {
        enemyType = Instantiate(pool[Random.Range(0, pool.Length)],
            _enemiesSpawnPoints[Random.Range(0, _enemiesSpawnPoints.Length)]).GetComponent<BaseEnemy>();
        enemyType.player = player;
    }
}
