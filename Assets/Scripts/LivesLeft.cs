using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LivesLeft : MonoBehaviour {

    Text daysLeft;
	// Use this for initialization
	void Start () {
        daysLeft = GetComponent<Text>();
        if(GameVariables.lives > 1)
        {
            daysLeft.text = "You have " + GameVariables.lives + " days left";
        } else
        {
            daysLeft.text = "You have " + GameVariables.lives + " day left";
        }
        
	}

}
