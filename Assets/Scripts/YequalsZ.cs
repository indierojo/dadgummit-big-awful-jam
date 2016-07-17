using UnityEngine;
using System.Collections;

public class YequalsZ : MonoBehaviour {

	// Use this for initialization

	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
	}
}
