using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int ArrowDamage = 10;

    public float ArrowFireRate = 1.0f;

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
}
