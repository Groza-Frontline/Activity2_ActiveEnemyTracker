using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class EnemyTracker : MonoBehaviour
{
    //1. Generic List Inititalization
    private List<string> activeEnemies = new List<string>();

    [SerializeField] private TMP_Text enemyListText;

    private int enemyCounter = 1;

    private void Start()
    {
        UpdateEnemyUI();
    }

    //2. Add Operation (Create)
    public void AddTarget()
    {
        string enemyName = "Enemy " + enemyCounter++;
        activeEnemies.Add(enemyName);

        UpdateEnemyUI();
    }

    //3. Remove Operation (Delete)
    public void DefeatEnemy()
    {
        if (activeEnemies.Count > 0)
        {
            string enemyToRemove = activeEnemies[0];

            if(activeEnemies.Contains(enemyToRemove))
            {
                activeEnemies.Remove(enemyToRemove);
            }

            UpdateEnemyUI();
        }
        else
        {
            Debug.Log("No enemies to remove.");
        }
    }

    //4. Read Operation
    private void UpdateEnemyUI()
    {
        enemyListText.text = "ENEMY TRACKER\n\n";

        for (int i = 0; i < activeEnemies.Count; i++)
        {
            enemyListText.text += $"{activeEnemies[i]}\n";
        }

        enemyListText.text += $"\nTotal Enemies: {activeEnemies.Count}";
    }

    //4. Clear Operation
    public void ClearEnemy()
    {
        activeEnemies.Clear();

        UpdateEnemyUI();

        Debug.Log("Enemy cleared.");
    }
}