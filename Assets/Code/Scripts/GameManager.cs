using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private void Awake()
    {

        DontDestroyGameManager();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DontDestroyGameManager()
    {
        GameObject[] gameManagers = GameObject.FindGameObjectsWithTag("Game Manager");

        if (gameManagers.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}
