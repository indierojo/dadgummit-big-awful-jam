using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scene_Switch_Trigger : MonoBehaviour {

    public int sceneNumber = 0;
	// Use this for initialization

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
