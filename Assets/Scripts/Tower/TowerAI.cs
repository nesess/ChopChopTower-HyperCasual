using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();

    public GameObject nearestEnemy;

    

   

    private void FixedUpdate()
    {
        if(enemyList.Count>0)
        {
            float minDistance = Mathf.Infinity;
            foreach(GameObject enemy in enemyList)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if(distance<minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = enemy;
                }
            }
        }
        else
        {
            nearestEnemy = null;
        }
    }
}
