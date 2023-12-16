using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject CurrentCheckpoint;
    public Transform enemy;
    public AudioClip respawnAudio;

    public void RespawnEnemy(){
        Instantiate(enemy, transform.position , transform.rotation );
     }
    public void RespawnPlayer(){
        AudioManager.instance.RandomizeSFX(respawnAudio);
        FindObjectOfType<controller>().transform.position = CurrentCheckpoint.transform.position;
    }
}
