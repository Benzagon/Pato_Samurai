using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT GAME");
        Application.Quit();
    }

    public void NxtLvl()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void startTut()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
