using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour // change to collectible 
{
    public AudioClip collectedClip; // we're not using audio

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement controller = other.GetComponent<PlayerMovement>(); // change this to whatever you named player script 

        if (controller != null)
        {
            controller.count++;
	        Destroy(gameObject);
        }
    }
}
