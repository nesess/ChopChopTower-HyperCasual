using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTrigger : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<TowerAI>().enemyList.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<TowerAI>().enemyList.Remove(other.gameObject);
    }

}
