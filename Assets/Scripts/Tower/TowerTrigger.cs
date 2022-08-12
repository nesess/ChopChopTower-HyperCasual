using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<TowerAI>().enemyList.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<TowerAI>().enemyList.Remove(other.gameObject);
    }
}