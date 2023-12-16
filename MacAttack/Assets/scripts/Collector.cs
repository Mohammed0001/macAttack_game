using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{   
    public int coinValue = 2;
    public AudioClip collectAudio;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            AudioManager.instance.RandomizeSFX(collectAudio);
            FindObjectOfType<playerStat>().collect(coinValue);
            Destroy(this.gameObject);
        }
    }

}
