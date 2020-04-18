using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathwallManager : MonoBehaviour
{

    [Header("Script References")]
    public GameplayManager gameplayManager;

    // Start is called before the first frame update
    void Start()
    {
        gameplayManager = GameObject.FindGameObjectWithTag("Gameplay Manager").GetComponent<GameplayManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit the ground!");
            gameplayManager.GameOver();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Friend" || collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
