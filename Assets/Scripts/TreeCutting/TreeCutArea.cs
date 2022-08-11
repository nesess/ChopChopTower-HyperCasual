using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TreeCutArea : MonoBehaviour
{
    [SerializeField]
    private GameObject logContainer;

    [SerializeField]
    private float throwForce = 50f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerChopping>()!=null)
        {
            other.GetComponent<PlayerChopping>().StartChopping();
            other.GetComponent<PlayerChopping>().trees = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerChopping>() != null)
        {
            other.GetComponent<PlayerChopping>().EndChopping();
        }
    }

    public void TreeChopped()
    {
        transform.GetChild(0).DOShakeScale(0.1f,Vector3.up,1,0,true).OnComplete(()=>
        SpawnLog());
        

    }

    private void SpawnLog()
    {
        GameObject log = logContainer.transform.GetChild(0).gameObject;
        log.transform.SetParent(this.gameObject.transform, false);
        log.transform.localPosition = new Vector3(0, 4.6f, 0);
        log.GetComponent<Rigidbody>().isKinematic = false;
        log.GetComponent<Rigidbody>().AddForce(throwForce * new Vector3(Random.Range(-0.5f, 0.5f), 1, Random.Range(-1f, -0.5f)));
    }

}
