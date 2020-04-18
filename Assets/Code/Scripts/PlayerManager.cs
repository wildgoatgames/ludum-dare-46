using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Script References")]
    public GameplayManager gameplayManager;

    [Header("Physics")]
    public Rigidbody2D playerRb;
    public float movementSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MovementController();
    }

    void MovementController()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            //Debug.Log("Make the ship go up!");
            
            if(gameplayManager.fuelValue > 0)
            {
                playerRb.AddForce(transform.up * movementSpeed, ForceMode2D.Impulse);
                gameplayManager.fuelValue -= gameplayManager.fuelCost;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Debug.Log("Hit the ground!");
            Destroy(this.gameObject);
            gameplayManager.GameOver();
        }
    }
}
