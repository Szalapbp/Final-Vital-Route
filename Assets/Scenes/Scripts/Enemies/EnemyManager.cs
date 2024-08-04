using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    private List<Enemy> activeEnemies = new List<Enemy>();

    [SerializeField] private TextMeshProUGUI enemiesRemaining;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterEnemy(Enemy enemy)
    {
        activeEnemies.Add(enemy);
        UpdateEnemiesRemainingUI();
    }

    public void UnregisterEnemy(Enemy enemy)
    {
        activeEnemies.Remove(enemy);
        UpdateEnemiesRemainingUI();
    }

    public bool EnemiesEliminated()
    {
        return activeEnemies.Count == 0;
    }

    private void UpdateEnemiesRemainingUI()
    {
        if(enemiesRemaining != null)
        {
            enemiesRemaining.text = "Enemies Remaining: " + activeEnemies.Count;
        }
    }
}
