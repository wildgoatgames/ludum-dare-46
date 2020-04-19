using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLibrary : MonoBehaviour
{
    [Header("Prefabs")]
    public List<GameObject> frenemyWords = new List<GameObject>();

    [Header("Word Lists")]
    public TextAsset friendlyWords;
    public TextAsset enemyWords;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
