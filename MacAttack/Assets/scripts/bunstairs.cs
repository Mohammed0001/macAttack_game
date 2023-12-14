
using System.Collections;
using UnityEngine;

public class bunstairs : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite explodedBlock;
    private Sprite originalSprite;
    private bool isPlayerOnBrick = false;

    public float flickerDuration = 1f;
    public float disappearTime = 5f;
    public float appearTime = 3f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalSprite = sr.sprite;
    }

    void Update()
    {
        if (isPlayerOnBrick)
        {
            StartCoroutine(FlickerAndDisappear());
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        // Check if the collision is with the player and the contact point is below the brick
        if (other.gameObject.CompareTag("Player") && other.GetContact(0).point.y > transform.position.y)
        {
            isPlayerOnBrick = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        // Reset the flag when the player leaves the brick
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayerOnBrick = false;
        }
    }

    IEnumerator FlickerAndDisappear()
    {
        // Flicker before disappearing
        yield return StartCoroutine(FlickerEffect(flickerDuration));

        // Wait for specified disappear time
        yield return new WaitForSeconds(disappearTime);

        // Set the sprite to explodedBlock
        sr.sprite = explodedBlock;

        // Wait for specified appear time
        yield return new WaitForSeconds(appearTime);

        // Reset the sprite to the original sprite
        sr.sprite = originalSprite;

        // Reset the flag
        isPlayerOnBrick = false;
    }

    IEnumerator FlickerEffect(float duration)
    {
        float flickerStartTime = Time.time;

        while (Time.time < flickerStartTime + duration)
        {
            // Toggle visibility by changing alpha value
            sr.enabled = !sr.enabled;

            // Wait for a short duration between toggles
            yield return new WaitForSeconds(0.1f);
        }

        // Ensure the sprite renderer is enabled when the flicker effect ends
        sr.enabled = true;
    }
}