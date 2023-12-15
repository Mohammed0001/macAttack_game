using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyingbomb : EnemyController
{
    public float VerticalSpeed;
    public float Amplitude;
    public float MinY; // Set the minimum y position
    public float MaxY; // Set the maximum y position

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Vertical movement using a sine wave
        float verticalMovement = Mathf.Sin(Time.time * VerticalSpeed) * Amplitude;
        float newY = startPosition.y + verticalMovement;

        // Clamp the y position to stay within the specified range
        newY = Mathf.Clamp(newY, MinY, MaxY);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            FindObjectOfType<playerStat>().TakeDamage(damage);
            FlipY(); // Reverse the vertical direction when hitting the player
        }

    }


    // Reverse the vertical direction
    public void FlipY()
    {
        VerticalSpeed = -VerticalSpeed;
    }
}