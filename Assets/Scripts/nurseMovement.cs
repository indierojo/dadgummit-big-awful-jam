using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class nurseMovement : MonoBehaviour {


    Animator anim;
    public float speed = 0;
    private float movex = 0f;
    private float movey = 0f;
    private bool isWalking = false;
    private Rigidbody2D rb;

    public string path;
    private char direction;
    private float destination;
    private int pathPosition = -1;

    public float sightDistance = 1;
    RaycastHit2D hit;
    bool spotted = false;
    Vector2 current;
    public Transform sightSpot;

    public GameObject expression;
    SpriteRenderer exRender;
    public int sceneNumber = 0;
    

    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        exRender = expression.GetComponent<SpriteRenderer>();
        RayCasting();
        readPath();
        spotted = false;
    }
	
	void FixedUpdate () {
        RayCasting();
        switch (direction)
        {
            case 'n':
                if (transform.position.y < destination)
                {
                    movey = 1;
                    movex = 0;
                } else
                {
                    Vector3 pos = transform.position;
                    pos.y = destination;
                    transform.position = pos;
                    movey = 0;
                    readPath();
                }
                break;
            case 'e':
                if (transform.position.x < destination)
                {
                    movey = 0;
                    movex = 1;
                }
                else
                {
                    Vector3 pos = transform.position;
                    pos.x = destination;
                    transform.position = pos;
                    movex = 0;
                    readPath();
                }
                break;
            case 's':
                if (transform.position.y > destination)
                {
                    movey = -1;
                    movex = 0;
                }
                else
                {
                    Vector3 pos = transform.position;
                    pos.y = destination;
                    transform.position = pos;
                    movey = 0;
                    readPath();
                }
                break;
            case 'w':
                if (transform.position.x > destination)
                {
                    movey = 0;
                    movex = -1;
                }
                else
                {
                    Vector3 pos = transform.position;
                    pos.x = destination;
                    transform.position = pos;
                    movex = 0;
                    readPath();
                }
                break;
        }

        isWalking = (Mathf.Abs(movex) + Mathf.Abs(movey) > 0);

        anim.SetBool("isWalking", isWalking);
        if (isWalking)
        {
            anim.SetFloat("x", movex);
            anim.SetFloat("y", movey);
        }
        rb.velocity = new Vector2(movex * speed, movey * speed);
               
    }

    void readPath()
    {
        pathPosition++;

        if (pathPosition >= path.Length - 1)
        {
            pathPosition = 0;
        }

        int distPath = path[pathPosition] - '0';
        pathPosition++;
        direction = path[pathPosition];

        switch (direction)
        {
            case 'n':
                destination = (distPath * .32f) + transform.position.y;
                break;
            case 'e':
                destination = (distPath * .32f) + transform.position.x;
                break;
            case 's':
                destination = transform.position.y - (distPath * .32f);
                break;
            case 'w':
                destination = transform.position.x - (distPath * .32f);
                break;
        }
        destination = (float)Math.Round(destination, 2);
        //Debug.Log("Current: " + transform.position.x + ", " + distPath + direction + " Destination: " + destination);
        
    }

    void RayCasting()
    {
        switch (direction)
        {
            case 'n':
                current = sightSpot.TransformDirection(Vector2.up);
                break;
            case 'e':
                current = sightSpot.TransformDirection(Vector2.right);
                break;
            case 's':
                current = sightSpot.TransformDirection(Vector2.down);
                break;
            case 'w':
                current = sightSpot.TransformDirection(Vector2.left);
                break;
        }
        
        
        
        hit = Physics2D.Raycast(sightSpot.position, current, (float)(sightDistance * .32), ~(1 << LayerMask.NameToLayer("Enemy")));
        //Debug.Log("hit: " + hit.collider.gameObject.name + " Distance: " + hit.distance);
        
        if (!spotted && hit.collider != null && hit.collider.gameObject.name == "player")
        {
            //Debug.Log("hit: " + hit.collider.gameObject.name + " Distance: " + hit.distance);
            exRender.enabled = true;
            speed = 0;
			playerMovement.speedMultiplier = 0;
			//GameVariables.music.spatialBlend = .60f;
            spotted = true;
            StartCoroutine(WaitTime(2));
        }
            
    }

    IEnumerator WaitTime(int a)
    {
        yield return new WaitForSeconds(a);

        playerMovement.speedMultiplier = 1;
        
        Debug.Log(GameVariables.lives);
        if(GameVariables.lives <= 1)
        {
            SceneManager.LoadScene("Lose");
            Debug.Log("Lost");
        } else
        {
            GameVariables.lives -= 1;
			//GameVariables.music.UnPause ();
            SceneManager.LoadScene(sceneNumber);
        }
        
    }

    void Behaviors()
    {

    }

}
