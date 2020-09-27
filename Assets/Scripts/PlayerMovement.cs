using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // public int scale = 15; 
    public float speed = 10.0f;
    public bool pause; 
    private Vector2 direction = Vector2.zero;
    public int score;
    [System.NonSerialized]
    public int count;
    SceneSwitcher sw;

    float horizontal; 
    float vertical; 
    Rigidbody2D rigidbody; 

    // Start is called before the first frame update
    void Start()
    {
        pause = false; 
        rigidbody = GetComponent<Rigidbody2D>();
        sw = GetComponent<SceneSwitcher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pause == false)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
        }

        if (score == count)
        {
            sw.setWinState(true);
        }

    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody.MovePosition(position);
    }


    void UpdateOrientation()
    {
        if (direction == Vector2.left)
        {
            // transform.localScale = new Vector3(-scale, scale, scale);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.up)
        {
            // transform.localScale = new Vector3(scale, scale, scale);
            transform.localRotation = Quaternion.Euler(0, 0, 90); 
        }
        else if (direction == Vector2.right)
        {
            // transform.localScale = new Vector3(scale, scale, scale);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Vector2.down)
        {
            // transform.localScale = new Vector3(scale, scale, scale);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }


}
