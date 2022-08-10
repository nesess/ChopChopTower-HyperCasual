using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    PlayerStack playerStack;

    private void Awake()
    {
        playerStack = GetComponent<PlayerStack>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(playerStack.StackList.Count < 20)
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;

            playerStack.CollectObject(other.gameObject);
        }
        
    }

   
}
