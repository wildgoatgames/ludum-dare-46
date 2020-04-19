using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [Header("Script References")]
    public AssetLibrary assetLibrary;

    [Header("Word Lists")]
    public string[] friendlyWordsList;
    public string[] enemyWordsList;

    // Start is called before the first frame update
    void Start()
    {
        ParseWordLists();
        Debug.Log($"Friendly word is: {GenerateWord(friendlyWordsList)}");
        Debug.Log($"Enemy word is: {GenerateWord(enemyWordsList)}");
    }

    void ParseWordLists()
    {
        friendlyWordsList = assetLibrary.friendlyWords.text.Split('\n');
        enemyWordsList = assetLibrary.enemyWords.text.Split('\n');
    }

    public string GenerateWord(string[] wordList)
    {
        string sourceWord = PullSourceWord(wordList, GenerateWordSelector(wordList));
        string outputWord;

        if (wordList == friendlyWordsList)
        {
            outputWord = sourceWord.Replace("it", "__");
        }
        else
        {
            outputWord = sourceWord.Replace("ti", "__");
        }

        Debug.Log($"sourceWord was: {sourceWord}. Final output tSwapped is: {outputWord}");
        return outputWord;
    }

    int GenerateWordSelector(string[] wordList)
    {
        int wordSelector = Random.Range(0, wordList.Length - 1);

        return wordSelector;
    }

    string PullSourceWord(string[] wordList, int wordSelector)
    {
        string sourceWord = wordList[wordSelector];

        return sourceWord;
    }
}
