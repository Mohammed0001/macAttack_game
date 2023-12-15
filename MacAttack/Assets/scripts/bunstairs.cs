using System.Collections;
using UnityEngine;

public class bunstairs : MonoBehaviour
{
    private SpriteRenderer sr;

    public Sprite explodedBlock;

    private bool playerOnBrick = false;
    private float timeOnBrick = 0f;
    private bool brickVisible = true;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (playerOnBrick)
        {
            timeOnBrick += Time.deltaTime;

            if (timeOnBrick >= 3f)
            {
                if (brickVisible)
                {
                    // Flicker effect (you can modify this part based on your requirements)
                    StartCoroutine(FlickerEffect());
                    brickVisible = false;
                }

                if (timeOnBrick >= 5f) // 3 seconds on brick + 2 seconds reappear time
                {
                    // Reappear the brick (you can add a visual effect or animation)
                    Reappear();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && other.GetContact(0).point.y < transform.position.y)
        {
            playerOnBrick = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnBrick = false;
        }
    }

    private IEnumerator FlickerEffect()
    {
        // Simple flicker effect: toggle visibility for a short duration
        gameObject.SetActive(false);
        yield return new WaitForSeconds(0.1f); // Adjust as needed
        gameObject.SetActive(true);
    }

    private void Reappear()
    {
        // Reset the brick appearance
        brickVisible = true;
        timeOnBrick = 0f;
        gameObject.SetActive(true);
    }
}