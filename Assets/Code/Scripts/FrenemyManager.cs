using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrenemyManager : MonoBehaviour
{
    [Header("Script References")]
    public GameplayManager gameplayManager;

    [Header("Gameplay Bools")]
    public bool isFriend;

    [Header("Frenemy Attributes")]
    public Rigidbody2D frenemyRb;
    
    // Start is called before the first frame update
    void Start()
    {
        gameplayManager = GameObject.FindGameObjectWithTag("Gameplay Manager").GetComponent<GameplayManager>();
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
            Debug.Log("Collided with friendly word, increase fuel!");
            IncreaseFuelValue();
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player" && isFriend == false)
        {
            Debug.Log("Collided with enemy word, game over!");
            gameplayManager.GameOver();
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Frenemy with something else.");
        }
    }

    void IncreaseFuelValue()
    {
        if (gameplayManager.fuelRemaining + gameplayManager.fuelValue < 100)
        {
            gameplayManager.fuelRemaining += gameplayManager.fuelValue;
        }
        else
        {
            gameplayManager.fuelRemaining = 100;
        }
    }
}
