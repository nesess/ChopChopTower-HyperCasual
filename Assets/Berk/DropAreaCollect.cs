using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DropAreaCollect : MonoBehaviour
{

    [SerializeField]
    private float collectFrequency = 0.1f;

    [SerializeField]
    private TextMeshProUGUI objectCountText;

    private PlayerStack playerStack;

    private int areaObjectCount = 0;
    [SerializeField]
    private int countMax = 50;

    private bool canCollect = false;

    private void OnTriggerEnter(Collider other)
    {
        playerStack = other.GetComponentInChildren<PlayerStack>();
        StartCoroutine(collectFromPlayer(collectFrequency));
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    private IEnumerator collectFromPlayer(float time)
    {
        while(true)
        {
            if(playerStack.StackList.Count >0)
            {
                GameObject lastObj = playerStack.StackList[playerStack.StackList.Count - 1];
                lastObj.transform.parent = null;
                playerStack.StackList.Remove(lastObj);
                lastObj.transform.DOMove(transform.position, 0.5f).SetEase(Ease.InOutSine).OnComplete(() =>
                lastObj.transform.DOScale(new Vector3(0, 0, 0), 0.3f)).OnComplete(() =>
                Destroy(lastObj));
                areaObjectCount++;
                objectCountText.text = areaObjectCount + "/" + countMax;

                //if max do upgrade
                yield return new WaitForSeconds(time);
            } 
            else
            {
                break;
            }
        }
    }

}
