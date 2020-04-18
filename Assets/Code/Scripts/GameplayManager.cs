using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [Header("Script References")]
    public PlayerManager playerManager;

    [Header("Gameplay Bools")]
    public bool gameOverTriggered;

    [Header("Object References")]
    public GameObject fuelGauge;

    [Header("Fuel Variables")]
    public float fuelValue;
    public float fuelCost;

    private void Start()
    {
        
    }

    void Update()
    {
        FuelCheck();
    }

    private void FuelCheck()
    {
        if(fuelValue <= 0)
        {
            GameOver();
        }
    }



    public void GameOver()
    {
        if(gameOverTriggered != true)
        {
            Debug.Log("Game over!");
            gameOverTriggered = true;
        }
        
    }


}
