using System;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Transform enemyDefaultLocation;
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private EnemyMovement enemyMovement;
    
    public int health = 100;
    private static int _enemyMaxHealth = 10;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        enemyDefaultLocation = GameObject.Find("EnemyDefaultPosition").transform;
        enemyManager = GameObject.Find("Enemies").GetComponent<EnemyManager>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        if (health < 0)
        {
            GameManager.instance.AddMoney();
            enemyManager.AddEnemyToList(gameObject);
            enemyManager.ReduceNextWaveCount();
            SetDefaults();
            enemyMovement.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "DeathPlane")
        {
            health = -1;
        }
    }

    #endregion

    private void SetDefaults()
    {
        transform.position = enemyDefaultLocation.position;
        health = _enemyMaxHealth;
    }

    public int Damage(int damage)
    {
        health -= damage;
        return health;
    }

    public static void IncreaseEnemyMaxHealth(int waveCount)
    {
        _enemyMaxHealth = waveCount * 10;
    }

    public void WaveIncrease()
    {
        health = _enemyMaxHealth;
        transform.position = enemyDefaultLocation.position;
    }
}
