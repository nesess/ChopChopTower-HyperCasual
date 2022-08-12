using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyText;

    public static UIManager instance;

    private void Awake()
    {
        if (UIManager.instance)
        {
            Destroy(base.gameObject);
        }
        else
        {
            UIManager.instance = this;
        }
    }

    private void Start()
    {
        RefreshMoneyText();
    }

    public void RefreshMoneyText()
    {
        moneyText.text = GameManager.instance.GetMoney() + " $";
    }

}
