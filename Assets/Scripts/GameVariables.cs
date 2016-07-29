using UnityEngine;
using System.Collections;

public class GameVariables : MonoBehaviour {

	public static AudioSource music;
    public static int lives = 3;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
		music = transform.GetComponent<AudioSource> ();
		music.spatialBlend = .90f;
		music.loop = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
