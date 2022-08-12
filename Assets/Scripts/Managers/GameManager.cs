using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int ArrowDamage = 10;

    public float ArrowFireRate = 1.0f;

    private int money = 0;

    private void Awake()
    {
        if (GameManager.instance)
        {
            Destroy(base.gameObject);
        }
        else
        {
            GameManager.instance = this;
        }
    }

    public int GetMoney()
    {
        return money;
    }
  
    public void SubtractMoney(int amount)
    {
        money -= amount;
        UIManager.instance.RefreshMoneyText();
    }

    public void AddMoney()
    {
        money += 10;
        UIManager.instance.RefreshMoneyText();
    }

}
