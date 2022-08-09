using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerStack : MonoBehaviour
{

    public List<GameObject> StackList = new List<GameObject>();


    [SerializeField]
    private float stackSpace = 0.5f;

    [SerializeField]
    private float pickupTime = 0.5f;

    private void AddStackList(GameObject obj)
    {
        
        obj.transform.localPosition = Vector3.zero;
        obj.transform.localPosition += stackSpace* StackList.Count * Vector3.up;
        StackList.Add(obj);    
    }

    public void CollectObject(GameObject obj)
    {

        obj.transform.SetParent(transform, true);
        Vector3 targetPos = new Vector3(0, stackSpace * (StackList.Count - 1), 0);
        obj.transform.DOLocalMove(targetPos, pickupTime).SetEase(Ease.InOutSine).OnComplete(()=> AddStackList(obj));
       
        
        
    }

   

}
