using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerCollector : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            FindObjectOfType<playerStat>().addBurger();
            Destroy(this.gameObject);
        }
    }
}
