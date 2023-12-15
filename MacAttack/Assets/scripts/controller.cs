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

    public KeyCode shootBrgr;
    public KeyCode shootFries;


    public Transform groundCheck;
    public Transform firePoint;

    public GameObject firesBullet;
    public GameObject burgerbullet;

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
    void Update()
    {
        if (Input.GetKeyDown(shootBrgr))
        {
            Shoot(1);
        }
        if (Input.GetKeyDown(shootFries))
        {
            Shoot(2);
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

    public void Shoot(int t){
        if(t == 1 && FindObjectOfType<playerStat>().getBurgers() > 0){
            Instantiate(burgerbullet, firePoint.position, firePoint.rotation);
            FindObjectOfType<playerStat>().decreaseBurgers();
        }else if(t == 2 && FindObjectOfType<playerStat>().getFries() > 0){
            Instantiate(firesBullet, firePoint.position, firePoint.rotation);
            FindObjectOfType<playerStat>().decreaseFries();
        }
    }
}
