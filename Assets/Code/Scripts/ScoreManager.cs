using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int currentScore;
    public int highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        GetHighScore();
        InvokeRepeating("IncreaseScore", 0f, 0.01f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreaseScore()
    {
        currentScore += 1;
    }

    public void GetHighScore()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
            //Debug.Log($"highScore exists in PlayerPrefs, updated to: {highScore}");
        }
        else
        {
            highScore = 0;
            //Debug.Log($"highScore does not exist in PlayerPrefs, reset to: {highScore}");
        }
    }

    public void UpdateHighScore()
    {
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("highScore", highScore);
            PlayerPrefs.Save();

            //Debug.Log($"High score beaten! PlayerPrefs highScore is now: {PlayerPrefs.GetInt("highScore")}");
        }

        
    }

}
