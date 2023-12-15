using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float Speed;
    public float duration = 1.5f;
    public float bulletTime = 0;
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
        bulletTime = bulletTime + Time.deltaTime;
        if(bulletTime >= duration){
            Destroy(this.gameObject);        
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed,GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Enemy")
        {
            FindObjectOfType<playerStat>().addKill();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
