using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bunstairs : MonoBehaviour
{
    public float timeToDisappear = 3f; // Time in seconds before the platform disappears
    public float timeToReappear = 2f; // Time in seconds before the platform reappears

    private bool isPlayerOnPlatform = false;
    private float timeOnPlatform = 0f;

    private void Update()
    {
        if (isPlayerOnPlatform)
        {
            timeOnPlatform += Time.deltaTime;

            if (timeOnPlatform >= timeToDisappear)
            {
                this.gameObject.SetActive(false);
                //GetComponent<SpriteRenderer>().enabled = false; // Disappear the platform
                Invoke("ReappearPlatform", timeToReappear); // Reappear the platform after specified time
            }
        }
        else
        {
            timeOnPlatform = 0f; // Reset the timer when the player is not on the platform
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
        }
    }

    private void ReappearPlatform()
    {
        this.gameObject.SetActive(true);

        // GetComponent<SpriteRenderer>().enabled = true; // Reappear the platform
    }
}