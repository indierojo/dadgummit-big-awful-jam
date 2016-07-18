using UnityEngine;
using System.Collections;

public class GameVariables : MonoBehaviour {

    public static int lives = 3;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
