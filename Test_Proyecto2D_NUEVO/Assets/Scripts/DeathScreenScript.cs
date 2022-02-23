using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour {

    private int currentLevel;

	public void RestartGame()
    {
        currentLevel = Movement2D.levelCount;

        if(currentLevel > 0)
        { 
            SceneManager.LoadScene("Level "+ currentLevel);
        }
        else
        {
            SceneManager.LoadScene("Tutorial");
        }
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene("Menu");
    }
}
