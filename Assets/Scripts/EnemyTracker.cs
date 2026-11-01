using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class EnemyTracker : MonoBehaviour
{
    //1. Generic List Inititalization
    private List<string> activeEnemies = new List<string>();

    //2. SerializeField to link the TMP_Text component in the Unity Editor
    [SerializeField] private TMP_Text enemyListText;

    private int enemyCounter = 1;

    // Start is called before the first frame update
    private void Start()
    {
        UpdateEnemyUI();
    }

    //3. Add Operation (Create)
    public void AddTarget()
    {
        // Generate a unique enemy name using the counter
        string enemyName = "Enemy " + enemyCounter++;
        activeEnemies.Add(enemyName);

        // Update the UI after adding a new enemy
        UpdateEnemyUI();
    }

    //4. Remove Operation (Delete)
    public void DefeatEnemy()
    {
        // Check if there are any enemies to remove
        if (activeEnemies.Count > 0)
        {
            // Remove the first enemy in the list (FIFO)
            string enemyToRemove = activeEnemies[0];

            // Remove the enemy from the list
            if (activeEnemies.Contains(enemyToRemove))
            {
                activeEnemies.Remove(enemyToRemove);
            }

            UpdateEnemyUI();
        }
        else
        {
            // Log a message if there are no enemies to remove
            Debug.Log("No enemies to remove.");
        }
    }

    //4. Read Operation
    private void UpdateEnemyUI()
    {
        // Update the TMP_Text component to display the current list of active enemies
        enemyListText.text = "ENEMY TRACKER\n\n";

        // Loop through the activeEnemies list and append each enemy name to the text
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            enemyListText.text += $"{activeEnemies[i]}\n";
        }

        // Append the total count of active enemies to the text
        enemyListText.text += $"\nTotal Enemies: {activeEnemies.Count}";
    }

    //4. Clear Operation
    public void ClearEnemy()
    {
        // Clear the list of active enemies
        activeEnemies.Clear();

        UpdateEnemyUI();

        Debug.Log("Enemy cleared.");
    }
}