using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour {

    Image sr;
    float currentAlpha = 1;
    public float fadeTime = 1.5f;
    public bool fadeIn = true;
    public float waitTime = 2f;
    public Text daysLeft;
	// Use this for initialization
	void Start () {
        
        sr = GetComponent<Image>();
        playerMovement.speedMultiplier = 0;
        if (fadeIn)
        {
            sr.enabled = true;
            currentAlpha = 0;
            fadeTime = (float)(fadeTime/ 255);
            daysLeft = daysLeft.GetComponent<Text>();
            daysLeft.enabled = true;
            
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Debug.Log("SceneFader running");
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
            return;
        }

        currentAlpha += fadeTime;
        if (fadeIn)
        {
            sr.color = Color.Lerp(Color.black, Color.clear, currentAlpha);
            if(sr.color.a <= 0.05f)
            {
                sr.color = Color.clear;
                sr.enabled = false;
                daysLeft.enabled = false;
                enabled = false;
                playerMovement.speedMultiplier = 1;
            }
        } else
        {
            sr.color = Color.Lerp(sr.color, Color.black, fadeTime);
            if (sr.color.a >= .95f)
            {
                sr.color = Color.black;
            }
        }
	}
}
