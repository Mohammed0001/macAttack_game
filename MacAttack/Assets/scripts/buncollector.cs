using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buncollector : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<playerStat>().addBurger();
            Destroy(this.gameObject);
        }
    }
}
