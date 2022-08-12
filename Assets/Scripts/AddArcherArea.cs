using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddArcherArea : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI archerMoneyText;

    [SerializeField]
    private GameObject[] archerList;

    [SerializeField]
    private int archerBuyAmount = 100;

    private int archerNum = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(GameManager.instance.GetMoney() >= archerBuyAmount)
        {
            GameManager.instance.SubtractMoney(archerBuyAmount);
            archerList[archerNum].SetActive(true);
            archerNum++;
            if(archerNum >=3)
            {
                archerMoneyText.text = "MAX";
                GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                archerBuyAmount += archerBuyAmount;
                archerMoneyText.text = archerBuyAmount + "$";
            }
            
        }
    }
}
