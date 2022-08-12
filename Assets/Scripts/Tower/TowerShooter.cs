using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject targetEnemy;

    

    [SerializeField]
    private GameObject arrowContainer;

    [SerializeField]
    private GameObject shootPos;

    private void Start()
    {
        StartCoroutine(ShootCoroutine());
    }


    private IEnumerator ShootCoroutine()
    {
        while(true)
        {
            targetEnemy = GetComponent<TowerAI>().nearestEnemy;
            if(targetEnemy !=null)
            {

                Vector3 targetPostition = new Vector3(targetEnemy.transform.position.x,this.transform.position.y, targetEnemy.transform.position.z);
                this.transform.LookAt(targetPostition);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 180, transform.eulerAngles.z);
                GameObject arrow = arrowContainer.transform.GetChild(0).gameObject;
                arrow.transform.parent = null;
                arrow.transform.parent = arrowContainer.transform;
                arrow.transform.position = shootPos.transform.position;
                arrow.GetComponent<ArrowMovement>().Shoot(targetEnemy);
            }
            yield return new WaitForSeconds(GameManager.instance.ArrowFireRate);   
        }
    }
}
