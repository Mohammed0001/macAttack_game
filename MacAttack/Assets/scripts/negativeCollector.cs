using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class negativeCollector : MonoBehaviour
{ 
    public int negativeValue = 0;
    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            if(negativeValue == 2){
                FindObjectOfType<playerStat>().decreaseFries();
            }else{
                FindObjectOfType<playerStat>().decreaseBurgers();
            }
            Destroy(this.gameObject);
        }
    }
}
