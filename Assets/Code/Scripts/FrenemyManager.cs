using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrenemyManager : MonoBehaviour
{
    [Header("Script References")]
    public GameplayManager gameplayManager;
    public WordManager wordManager;

    [Header("Gameplay Bools")]
    public bool isFriend;

    [Header("Frenemy Attributes")]
    public Rigidbody2D frenemyRb;
    public string sourceWord;
    public TextMeshPro wordText;
    
    // Start is called before the first frame update
    void Start()
    {
        FindObjectReferences();
        UpdateWord();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FrenemyMovement();
    }

    void FrenemyMovement()
    {
        transform.Translate((Vector3.left * gameplayManager.frenemyMovementSpeed) * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isFriend == true)
        {
            //Debug.Log("Collided with friendly word, increase fuel!");
            gameplayManager.CorrectWord(sourceWord);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player" && isFriend == false)
        {
            //Debug.Log("Collided with enemy word, game over!");
            gameplayManager.GameOver();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Deathwall")
        {
            // Do nothing!
        }
        else
        {
            //Debug.Log("Frenemy with something else.");
        }
    }

    void UpdateWord()
    {
        string newWord;

        if (isFriend == true)
        {
            newWord = wordManager.GenerateWord(wordManager.friendlyWordsList, this.gameObject);
        }
        else
        {
            newWord = wordManager.GenerateWord(wordManager.enemyWordsList, this.gameObject);
        }

        wordText.SetText(newWord);
        //Debug.Log($"Word changed to {wordText.text}");
    }

    void FindObjectReferences()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Gameplay Manager");
        gameplayManager = manager.GetComponent<GameplayManager>();
        wordManager = manager.GetComponent<WordManager>();
    }
}
