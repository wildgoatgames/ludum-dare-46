using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameplayUIManager : MonoBehaviour
{
    [Header("Script References")]
    public GameplayManager gameplayManager;
    public ScoreManager scoreManager;

    [Header("Object References")]
    public Slider fuelGauge;
    public TextMeshProUGUI scoreValue;
    public GameObject gameOverScreen;
    public CanvasGroup gameOverScreenCanvasGroup;
    public TextMeshProUGUI gameOverScore;
    public TextMeshProUGUI gameOverHighScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateFuelGauge();
        UpdateScoreValue();
    }

    void UpdateFuelGauge()
    {
        fuelGauge.value = gameplayManager.fuelRemaining;
    }

    void UpdateScoreValue()
    {
        if(gameplayManager.gameOverTriggered != true)
        {
            scoreValue.SetText(scoreManager.currentScore.ToString("#,#"));
        }
    }

    public void EnableGameOverScreen()
    {
        gameOverScreenCanvasGroup.alpha = 1;
        gameOverScreenCanvasGroup.blocksRaycasts = true;
        gameOverScreenCanvasGroup.interactable = true;

        // Update scores
        gameOverScore.SetText(($"Score: {scoreManager.currentScore}"));
        gameOverHighScore.SetText(($"High Score: {scoreManager.highScore}"));
    }
}
