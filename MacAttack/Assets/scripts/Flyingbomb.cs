using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyingbomb : EnemyController
{
    public float HorizontalSpeed = 1.0f;
    public float VerticalSpeed = 1.0f;
    public float Amplitude = 1.0f;
    public float minY = 0.0f; // Set the minimum y position
    public float maxY = 5.0f; // Set the maximum y position

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Horizontal movement
        transform.Translate(Vector2.right * HorizontalSpeed * Time.deltaTime);

        // Vertical movement using a sine wave
        float verticalMovement = Mathf.Sin(Time.time * VerticalSpeed) * Amplitude;
        float newY = startPosition.y + verticalMovement;

        // Clamp the y position to stay within the specified range
        newY = Mathf.Clamp(newY, minY, maxY);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}