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
    		FindObjectOfType<controller>().playVictory();
			Invoke("ViewVictory" ,1);
    	}
	}
	void ViewVictory(){
        AudioManager.instance.RandomizeSFX(victoryAudio);
		victoryScreen.SetActive(true);
   		
	}
}
