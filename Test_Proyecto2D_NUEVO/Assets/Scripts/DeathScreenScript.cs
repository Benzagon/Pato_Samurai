using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenScript : MonoBehaviour {

	public void RestartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene("Menu");
    }
}
