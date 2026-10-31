using UnityEngine;
using System.Collections.Generic;
using TMPro;
public class EnemyTracker : MonoBehaviour
{
    //1. Generic List Declaration
    private List<string> activeEnemies = new List<string>();
    public TextMeshProUGUI enemyTrackerText;

    void Start()
    {
        //2. Add operation (Create)
        activeEnemies.Add("Goblin");
        activeEnemies.Add("Skeletor");
        activeEnemies.Add("Dark Minion");
        activeEnemies.Add("Chaos Knight");
        UpdateUI();
    }

    // Adds an item to the player's inventory
    public void AddTarget(string enemyName)
    {
        activeEnemies.Add(enemyName);
        //playerItems.Clear();
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

    //Drops the item when player dies
    public void RemoveItemDrop()
    {
        //Loop Backwards from end to 0
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            if (activeEnemies[i].Contains("Potion"))
            {
                activeEnemies.RemoveAt(i);
                Debug.Log("You have taken damage! 1 item is dropped!!! :(");
            }
            UpdateUI();
        }
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
