using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public int coinValue = 2;

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            FindObjectOfType<playerStat>().collect(coinValue);
            Destroy(this.gameObject);
        }
    }

}
