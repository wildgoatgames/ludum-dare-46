using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIManager : MonoBehaviour
{
    [Header("Script References")]
    public GameplayManager gameplayManager;

    [Header("Object References")]
    public Slider fuelGauge;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateFuelGauge();
    }

    void UpdateFuelGauge()
    {
        fuelGauge.value = gameplayManager.fuelRemaining;
    }
}
