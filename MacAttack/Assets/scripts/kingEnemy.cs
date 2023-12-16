using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kingEnemy : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;
    public GameObject victoryScreen;
    public AudioClip victoryAudio;
    public AudioClip bulletAudio;

    public int health = 10;
    public void shootBullet(){
        AudioManager.instance.RandomizeSFX(bulletAudio);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.tag == "Bullet"){
            if(health > 0){
                health-=1;
            }else{
                AudioManager.instance.RandomizeSFX(victoryAudio);
                victoryScreen.SetActive(true);
            }
        }
    }
}
