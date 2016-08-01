using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class gameOver : MonoBehaviour {

    public void ExitGame()
    {
        
        Application.Quit();
    }

    public void StartGame()
    {
        GameVariables.lives = 3;
        SceneManager.LoadScene(1);
    }
}
