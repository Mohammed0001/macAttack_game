using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeBun : MonoBehaviour
{
    public bool IsWinBun = false;
    
    void OnCollisionEnter2D(Collision2D other){
        if (other.GetContact(0).point.y > transform.position.y && !IsWinBun){
               Invoke("destroyBun", 1.5f);
        }
        if(IsWinBun){
            FindObjectOfType<mazeStat>().vicroty();
        }
    }
    //void OnTriggerEnter2D(Collider2D other){
    //}
    void destroyBun(){
        Object.Destroy(gameObject,.2f);
    }
}
