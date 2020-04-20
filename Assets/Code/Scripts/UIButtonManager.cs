using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonManager : MonoBehaviour
{
    public CanvasGroup mainMenu;
    public CanvasGroup howToPlayMenu;
    public CanvasGroup aboutMenu;



    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenMainMenu()
    {
        howToPlayMenu.alpha = 0;
        howToPlayMenu.interactable = false;
        howToPlayMenu.blocksRaycasts = false;

        aboutMenu.alpha = 0;
        aboutMenu.interactable = false;
        aboutMenu.blocksRaycasts = false;

        mainMenu.alpha = 1;
        mainMenu.interactable = true;
        mainMenu.blocksRaycasts = true;
    }

    public void OpenHowToPlayMenu()
    {
        aboutMenu.alpha = 0;
        aboutMenu.interactable = false;
        aboutMenu.blocksRaycasts = false;

        mainMenu.alpha = 0;
        mainMenu.interactable = false;
        mainMenu.blocksRaycasts = false;

        howToPlayMenu.alpha = 1;
        howToPlayMenu.interactable = true;
        howToPlayMenu.blocksRaycasts = true;
    }

    public void OpenAboutMenu()
    {
        howToPlayMenu.alpha = 0;
        howToPlayMenu.interactable = false;
        howToPlayMenu.blocksRaycasts = false;

        mainMenu.alpha = 0;
        mainMenu.interactable = false;
        mainMenu.blocksRaycasts = false;

        aboutMenu.alpha = 1;
        aboutMenu.interactable = true;
        aboutMenu.blocksRaycasts = true;
    }


}
