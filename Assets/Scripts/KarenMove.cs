using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenMove : MonoBehaviour
{

    public Transform[] waypoints;
    int cur = 0;
    public float speed = 0.3f;



    void FixedUpdate()
    {
        Debug.Log("multiple");
        // Waypoint not reached yet? then move closer
        //if (transform.position != waypoints[cur].position)
        if ((Math.Abs(transform.position.x - waypoints[cur].position.x) > .1) || (Math.Abs(transform.position.y - waypoints[cur].position.y) > .1) ) 
        {
            Vector2 p = Vector2.MoveTowards(transform.position,
                                           waypoints[cur].position,
                                           speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        // Waypoint reached, select next one
        else cur = (cur + 1) % waypoints.Length;
        Debug.Log(cur);
        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        // GetComponent<Animator>().SetFloat("DirX", dir.x);
        // GetComponent<Animator>().SetFloat("DirY", dir.y);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("helloooo");
        if ( collision.collider.GetType() == typeof(BoxCollider2D) && (collision.gameObject.tag == "Shelf" || collision.gameObject.tag == "Waypoint"))
        {
            // do stuff only for the box collider
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

}
