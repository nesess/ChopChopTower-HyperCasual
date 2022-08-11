using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    #region Variables

    public List<GameObject> enemyList;
    public List<GameObject> spawnPointList;

    [Space] public float timeInterval;
    [SerializeField] private float time;
    [SerializeField] private float timeIntervalDecreaseValue = 1;
    [SerializeField] private float minTimeInterval = 1;

    [Space] [SerializeField] private int nextWaveEnemyCount = 10;
    [SerializeField] private int baseNextWaveEnemyCount = 10;
    [SerializeField] private int addedEnemyCountToNextWave = 5;
    [SerializeField] private int waveNumber = 1;

    [Space] public List<GameObject> allEnemies;

    #endregion

    #region Unity Methods

    private void Update()
    {
        time += Time.deltaTime;

        if (timeInterval - time < .1f)
        {
            time = 0f;

            if (enemyList.Count > 0)
            {
                var lastEnemy = enemyList.Last();
                var randomSpawnPoint = spawnPointList[Random.Range(0, spawnPointList.Count)];
                var spawnPointPosition = randomSpawnPoint.transform.position;

                lastEnemy.transform.position = spawnPointPosition;

                lastEnemy.GetComponent<EnemyMovement>().enabled = true;
                enemyList.Remove(lastEnemy);

                if (nextWaveEnemyCount <= 0)
                {
                    ChangeTimeInterval();
                    nextWaveEnemyCount += baseNextWaveEnemyCount + addedEnemyCountToNextWave;
                    waveNumber++;

                    foreach (var enemy in allEnemies)
                    {
                        EnemyHealthManager.IncreaseEnemyMaxHealth(waveNumber);
                        enemy.GetComponent<EnemyHealthManager>().WaveIncrease();
                    }
                }
            }
        }
    }

    #endregion

    private void ChangeTimeInterval()
    {
        timeInterval -= timeIntervalDecreaseValue;

        if (timeInterval < minTimeInterval)
        {
            timeInterval = minTimeInterval;
        }
    }

    public void AddEnemyToList(GameObject enemy)
    {
        if (enemyList.IndexOf(enemy) == -1)
        {
            enemyList.Add(enemy);
        }
    }

    public void ReduceNextWaveCount()
    {
        nextWaveEnemyCount -= 1;
    }
}