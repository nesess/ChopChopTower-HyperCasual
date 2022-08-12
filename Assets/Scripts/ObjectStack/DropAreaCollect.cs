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
    [SerializeField]
    private TextMeshProUGUI dropAreaNameText;

    [SerializeField]
    private GameObject logContainer;

    private PlayerStack playerStack;

    private int areaObjectCount = 0;
    [SerializeField]
    private int countMax = 10;

    private int level = 1;

    private enum AreaType
    {
        Damage,
        FireRate
    }

    [SerializeField]
    private AreaType type;

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
                lastObj.transform.SetParent(logContainer.transform, false));
                lastObj.GetComponent<Rigidbody>().isKinematic = true;
                
                areaObjectCount++;
                

                if(areaObjectCount>=countMax)
                {
                    countMax += 10;
                    areaObjectCount = 0;
                    switch(type)
                    {
                        case AreaType.Damage:
                            GameManager.instance.ArrowDamage += 5;
                            level++;
                            dropAreaNameText.text = "Damage Lv" + level;
                            break;
                        case AreaType.FireRate:
                            if(GameManager.instance.ArrowFireRate>0.1f)
                            {
                                level++;
                                dropAreaNameText.text = "Shoot Rate Lv" + level;
                                GameManager.instance.ArrowFireRate -= 0.1f;
                            }
                            break;
                        default: Debug.Log("AREA TYPE ERROR");
                            break;
                    }
                }
                objectCountText.text = areaObjectCount + "/" + countMax;
                yield return new WaitForSeconds(time);
            } 
            else
            {
                break;
            }
        }
    }

}
