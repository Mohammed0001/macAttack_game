using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectiveZone : MonoBehaviour
{
        public float fireRate = 1.5f; // Bullets per second

    private float nextFireTime = 0f;
    void OnTriggerStay2D(Collider2D other){
        
        if(other.tag == "Player"){
        if (Time.time >= nextFireTime)
        {
            FindObjectOfType<kingEnemy>().shootBullet();        
                // Set the next allowed fire time based on the fire rate
                nextFireTime = Time.time + 1f / fireRate;
        }
        }
    }
}
