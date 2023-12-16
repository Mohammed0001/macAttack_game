using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friesCollector : MonoBehaviour
{
    public AudioClip friesCollect;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            AudioManager.instance.RandomizeSFX(friesCollect);
            FindObjectOfType<playerStat>().addFries();
            Destroy(this.gameObject);
        }
    }
}
