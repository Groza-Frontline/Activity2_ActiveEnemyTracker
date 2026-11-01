using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class EnemyTracker : MonoBehaviour
{
    //1. Generic List Initialization
    private List<string> activeEnemies = new List<string>();
    public TextMeshProUGUI enemyTrackerText;

    void Start()
    {
        //2. Add operation (Create)
        activeEnemies.Add("Megatron");
        activeEnemies.Add("Skeletor");
        activeEnemies.Add("Evil Minion");
        activeEnemies.Add("Chaos Knight");
        activeEnemies.Add("Front Man");
        activeEnemies.Add("Thanos");
        UpdateUI();
    }

    // Adds an enemy to the list and updates the UI
    public void AddTarget(string enemyName)
    {
        activeEnemies.Add(enemyName);
        //activeEnemies.Clear();
        UpdateUI();
    }

    // Remove operation (Delete)
    public void DefeatEnemy(string enemyName)
    {
        //3. REMOVE
        if (activeEnemies.Remove(enemyName))
        {
            Debug.Log($"Removed {enemyName} from enemy tracker");
        }
        else
        {
            Debug.LogWarning($"Could not {enemyName} to remove");
        }

        UpdateUI();
    }

    // Update is called once per frame
    private void UpdateUI()
    {
        //UPDATE
        enemyTrackerText.text = "Enemy Tracker: \n";
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            enemyTrackerText.text += $"{activeEnemies[i]}\n";
        }
    }
}
