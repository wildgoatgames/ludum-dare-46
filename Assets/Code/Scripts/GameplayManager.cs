using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [Header("Script References")]
    public PlayerManager playerManager;
    public AssetLibrary assetLibrary;
    public ScoreManager scoreManager;
    public GameplayUIManager gameplayUIManager;

    [Header("Gameplay Bools")]
    public bool gameOverTriggered;

    [Header("Object References")]
    public GameObject fuelGauge;

    [Header("Fuel Variables")]
    public float fuelRemaining;
    public float fuelCost;
    public float fuelValue;

    [Header("Frenemy Variables")]
    public int frenemyMovementSpeed;
    public float frenemyTimerMin;
    public float frenemyTimerMax;
    public float frenemyTimerValue;
    public int enemiesGenerated;
    public int friendsGenerated;


    void Start()
    {
        SetFrenemyTimer();
    }

    void Update()
    {
        
    }

    void SetFrenemyTimer()
    {
        if (gameOverTriggered != true)
        {
            frenemyTimerValue = Random.Range(frenemyTimerMin, frenemyTimerMax);
            //Debug.Log($"Frenemy timer value set to: {frenemyTimerValue}");

            InvokeRepeating("FrenemyTimerCountdown", 0, 0.1f);
        }
    }

    void FrenemyTimerCountdown()
    {
        if (gameOverTriggered != true)
        {
            if (frenemyTimerValue > 0)
            {
                frenemyTimerValue -= 0.1f;
                //Debug.Log($"frenemyTimerValue: {frenemyTimerValue}");
            }
            else if (frenemyTimerValue <= 0)
            {
                InstantiateFrenemy();
            }
            else
            {
                Debug.Log("Something went wrong with the FrenemyTimerCountDown() function.");
            }
        }        
    }

    void InstantiateFrenemy()
    {
        if (gameOverTriggered != true)
        {
            int frenemySelector = FrenemySelectorGenerator();
            Vector3 frenemyPosition = new Vector3(10, Random.Range(-3.2f, 3.2f), 0);

            Instantiate(assetLibrary.frenemyWords[frenemySelector], frenemyPosition, Quaternion.identity);
            //Debug.Log("Frenemy instantiated!");

            CancelInvoke();
            SetFrenemyTimer();
        }
    }

    int FrenemySelectorGenerator()
    {
        int finalValue;
        int proposedFrenemySelector = Random.Range(0 - friendsGenerated, 2 + enemiesGenerated);

        if (friendsGenerated >= 3)
        {
            // Generate enemy due to too many consecutive friends
            finalValue = 0;
            friendsGenerated = 0;
            enemiesGenerated++;
        }
        else if (enemiesGenerated >= 3)
        {
            // Generate friend due to too many consecutive enemies
            finalValue = 1;
            enemiesGenerated = 0;
            friendsGenerated++;
        }
        else
        {
            if (proposedFrenemySelector <= 0)
            {
                // Generate enemy
                friendsGenerated = 0;
                enemiesGenerated++;
                finalValue = 0;
            }
            else if (proposedFrenemySelector > 0)
            {
                // Generate friend
                enemiesGenerated = 0;
                friendsGenerated++;
                finalValue = 1;
            }
            else
            {
                Debug.Log("Something broke with generating the Frenemy Selector value.");
                finalValue = 0;
            }
        }

        return finalValue;
    }

    public void GameOver()
    {
        if(gameOverTriggered != true)
        {
            Debug.Log("Game over!");
            scoreManager.CancelInvoke();
            scoreManager.UpdateHighScore();
            gameplayUIManager.EnableGameOverScreen();
            DestroyAllGameObjects();
            gameOverTriggered = true;
        }
        
    }

    void DestroyAllGameObjects()
    {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
        {
            Destroy(player.gameObject);
        }

        foreach (GameObject enemyWord in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemyWord.gameObject);
        }

        foreach (GameObject friendlyWord in GameObject.FindGameObjectsWithTag("Friend"))
        {
            Destroy(friendlyWord.gameObject);
        }
    }

}
