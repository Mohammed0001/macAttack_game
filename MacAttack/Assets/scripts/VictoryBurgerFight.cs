using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryBurgerFight : MonoBehaviour
{
	public GameObject victoryScreen;
	void OnTriggerEnter2D(Collider2D other){
   		if(other.tag == "Player")
  		{
			Invoke("ViewVictory" ,3 );
    			FindObjectOfType<controller>().playVictory();
    		}
	}
	void ViewVictory(){
		victoryScreen.SetActive(true);
   		
	}
}
