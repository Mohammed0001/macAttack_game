using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryBurgerFight : MonoBehaviour
{
	public GameObject victoryScreen;
    public AudioClip victoryAudio;

	void OnTriggerEnter2D(Collider2D other){
   		if(other.tag == "Player")
  		{
        AudioManager.instance.RandomizeSFX(victoryAudio);
			Invoke("ViewVictory" ,3 );
    			FindObjectOfType<controller>().playVictory();
    		}
	}
	void ViewVictory(){
		victoryScreen.SetActive(true);
   		
	}
}
