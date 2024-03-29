﻿using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

    Animator anim;
    public static float speedMultiplier = 1f;
    public float speed = .7f;
    private float movex = 0f;
    private float movey = 0f;
    private bool isWalking = false;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        movex = Input.GetAxisRaw("Horizontal");
        movey = Input.GetAxisRaw("Vertical");

        isWalking = (Mathf.Abs(movex) + Mathf.Abs(movey) > 0);

        anim.SetBool("isWalking", isWalking);
        if (isWalking)
        {
            anim.SetFloat("x", movex);
            anim.SetFloat("y", movey);
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * speed * speedMultiplier, movey * speed * speedMultiplier);

    }

    
}
