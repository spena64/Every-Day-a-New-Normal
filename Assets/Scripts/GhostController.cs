using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    private float moveTimer; 
    public float timeToMoveChange = 3.0f;
    public float speed = 3.0f; 
    private Vector2 direction; 
    private Vector2 moveSmooth; 

    private bool left;
    private bool prev;
    Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        GetNewDirection();
    }

    // Update is called once per frame
    void Update()
    {
        // move cooldown
        moveTimer -= Time.deltaTime; 
        if (moveTimer < 0) 
        { 
            GetNewDirection(); 
            moveTimer = timeToMoveChange;  
        }

        // check direction
        CheckDirection();

        // move ghost 
        transform.position = new Vector2(transform.position.x + (moveSmooth.x * Time.deltaTime), 
        transform.position.y + (moveSmooth.y * Time.deltaTime));
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void GetNewDirection() 
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        moveSmooth = direction * speed;
        CheckDirection(); 
    }

    void OnCollisionEnter2D (Collision2D other)
    {
        switch(other.gameObject.name)
        {
            case "top":
                direction = new Vector2(Random.Range(-1.0f, 1.0f), -1.0f).normalized;
                moveSmooth = direction * speed;
                break; 
            case "right":
                direction = new Vector2(-1.0f, Random.Range(-1.0f, 1.0f)).normalized;
                moveSmooth = direction * speed;
                break; 
            case "bottom":
                direction = new Vector2(Random.Range(-1.0f, 1.0f), 1.0f).normalized;
                moveSmooth = direction * speed;
                break; 
            case "left":
                direction = new Vector2(1.0f, Random.Range(-1.0f, 1.0f)).normalized;
                moveSmooth = direction * speed;
                break; 
            default: 
                break; 
        } 

        CheckDirection(); 

        moveTimer = timeToMoveChange;
    }

    void CheckDirection()
    {
        if (direction.x < 0)
        {
            left = true;
        }
        else 
        {
            left = false;
        }

        if (prev != left)
        {
            prev = left;
            anim.transform.Rotate(0, 180, 0);
        }
        

    }
}
