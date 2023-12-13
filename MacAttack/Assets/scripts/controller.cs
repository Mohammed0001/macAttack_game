using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public bool isFacingRight;
    
    public AudioClip jump1;
    public AudioClip jump2;

    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;

    public KeyCode Return;


    public Transform groundCheck;
    public Transform firePoint;

    public GameObject bullet;

    public float groundCheckRadius;

    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anime;


    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        anime = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Return))
        {
            Shoot();
        }
        if (Input.GetKey(Spacebar) && grounded){
            jump();
        }
        if(Input.GetKey(L)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed ,GetComponent<Rigidbody2D>().velocity.y );
            if(isFacingRight){
                flip();
                isFacingRight = false;
            }
        }
        if(Input.GetKey(R)){
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed ,GetComponent<Rigidbody2D>().velocity.y );
            if(!isFacingRight){
                flip();
                isFacingRight = true;

            }
        }
        anime.SetFloat("speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        anime.SetBool("ground", grounded);
    }
    void FixedUpdate(){
        grounded = Physics2D.OverlapCircle(groundCheck.position , groundCheckRadius , whatIsGround);
    }

    void flip(){
        transform.localScale = new Vector3(-(transform.localScale.x) ,transform.localScale.y , transform.localScale.z);
    }
    void jump(){
         GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x , jumpHeight );
       // AudioManager.instance.RandomizeSFX(jump1,jump2);
    }

    public void Shoot(){
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    
}
