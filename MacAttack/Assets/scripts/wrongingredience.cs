using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wrongingredience : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<playerStat>().TakeDamage(1);
            Destroy(this.gameObject);
        }
    }
}