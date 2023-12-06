using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        controller player;
        player = FindObjectOfType<controller>();
        if (player.transform.localScale.x<0)
        {
            Speed = -Speed;
            transform.localScale = new Vector3(-(transform.localScale.x) , transform.localScale.y , transform.localScale.y);
        }
    }
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed,GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            
        }
        Destroy(this.gameObject);
    }
}
