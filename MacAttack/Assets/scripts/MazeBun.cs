using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBun : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other){
        
        if (other.GetContact(0).point.y > transform.position.y){
               Invoke("destroyBun", 1.5f);
        }
        
    }
    void destroyBun(){
        Object.Destroy(gameObject,.2f);
    }
}
