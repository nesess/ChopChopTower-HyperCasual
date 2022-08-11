using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    #region Variables

    public List<GameObject> enemyList;
    public List<GameObject> spawnPointList;

    public float timeInterval;
    [SerializeField] private float time;
    [SerializeField] private float timeIntervalDecreaseValue = 1;
    [SerializeField] private float minTimeInterval = 1;

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
                ChangeTimeInterval();
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
        enemyList.Add(enemy);
    }
}