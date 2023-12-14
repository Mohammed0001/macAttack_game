using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class playerStat : MonoBehaviour
{
    
    public int health = 6 ;
    public int lives = 3;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI livesUI;
    private float flickerTime = 0f;
    private float flickerDuration = 0.1f;
    private int kills = 0;
    
    private SpriteRenderer spriteRenderer;
    public GameObject gameOverScreen;
    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    public Image healthBar;
    public int coinsCollected = 0;
    // Start is called before the first frame update
    void Start()
    {
        livesUI.text = "" + lives;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       scoreUI.text = "" + kills;
        if(this.isImmune == true){
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
        if(immunityTime >= immunityDuration){
            this.isImmune = false;
            this.spriteRenderer.enabled = true;
        }
       } 
    }

    void SpriteFlicker(){
        if(this.flickerTime < this.flickerDuration){
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }else if(this.flickerTime >= this.flickerDuration){
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }
    public void TakeDamage(int damage){
        if(this.isImmune == false){
            this.health = health - damage;
           // healthBar.fillAmount = this.health / 10f;
            if(this.health < 0)
                this.health = 0;
            if(this.lives > 0 && this.health == 0){
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6;
                this.lives--;
                livesUI.text = "" + lives;
            }else if(this.lives == 0 && this.health == 0){
                Debug.Log("GameOver!");
                gameOverScreen.SetActive(true);
                Destroy(this.gameObject);
            }
            Debug.Log("Player Health: " + this.health.ToString());
            Debug.Log("Player Lives: " + this.lives.ToString());
        }
        PlayHitReaction();
    }
    void PlayHitReaction(){
        this.isImmune = true;
        this.immunityTime = 0f;
    }
    public void collect(int coinValue)
    {
        coinsCollected += coinValue;
    }
    public void addKill(){
        kills+=1;
    }
}
