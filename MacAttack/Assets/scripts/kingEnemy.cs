using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kingEnemy : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject victoryScreen;
    public int health = 10;
    public void shootBullet(){
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Bullet"){
            if(health > 0){
                health-=1;
            }else{
                victoryScreen.SetActive(true);
            }
        }
    }
}
