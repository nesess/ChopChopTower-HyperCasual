using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ArrowMovement : MonoBehaviour
{
    private Rigidbody rigid;
    private GameObject target;
    [SerializeField]
    private float speed = 5.0f;
    [SerializeField]
    private float rotateSpeed = 100.0f;
    [SerializeField]
    private int damage = 10; // remove this use gamemanager arrow damage
    private bool targetReached = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }


    public void Shoot(GameObject enemy)
    {
        target = enemy;
        targetReached = false;
        StartCoroutine(ArrowPoolCoroutine());
        StartCoroutine(ShootCoroutine());
        damage = GameManager.instance.ArrowDamage;
    }
    private IEnumerator ArrowPoolCoroutine()
    {
        yield return new WaitForSeconds(3.0f);
        rigid.velocity = Vector3.zero;
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
    }

    private IEnumerator ShootCoroutine()
    {
        while(true)
        {
            if(target != null)
            {
                if (!targetReached)
                {
                    //rigid.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotateSpeed * Time.deltaTime);
                    transform.LookAt(target.transform);
                    rigid.velocity = transform.forward * speed;
                }
                else 
                { 
                    break;
                }

                //remove when collider implemented
                if (Vector3.Distance(transform.position, target.transform.position) < 1)
                {
                    targetReached = true;
                }

                
            }
            else
            {
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //stop and stick target
    }


}
