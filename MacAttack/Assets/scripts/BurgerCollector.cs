using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCollector : MonoBehaviour
{
    public AudioClip burgerCollect;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            AudioManager.instance.RandomizeSFX(burgerCollect);

            FindObjectOfType<playerStat>().addBurger();
            Destroy(this.gameObject);
        }
    }
}
