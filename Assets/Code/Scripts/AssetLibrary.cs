using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetLibrary : MonoBehaviour
{
    [Header("Prefabs")]
    public List<GameObject> frenemyWords = new List<GameObject>();
    public GameObject correctWord;

    [Header("Word Lists")]
    public TextAsset friendlyWords;
    public TextAsset enemyWords;
}
