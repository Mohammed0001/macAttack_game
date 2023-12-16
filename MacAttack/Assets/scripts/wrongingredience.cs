using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrongingredience : MonoBehaviour
{
    public AudioClip wrongCollectAudio;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.RandomizeSFX(wrongCollectAudio);
            FindObjectOfType<playerStat>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}