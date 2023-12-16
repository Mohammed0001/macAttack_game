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
    public TextMeshProUGUI coinsUI;
    public GameObject[] livesUIs;
    public TextMeshProUGUI burgersUI;
    public TextMeshProUGUI friesUI;

    private float flickerTime = 0f;
    private float flickerDuration = 0.1f;
    
    private int kills = 0;
    
    private SpriteRenderer spriteRenderer;
    public GameObject gameOverScreen;

    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;

    public Image healthBar;
    public static int coinsCollected = 0;

    static public int friesBullets = 0;
    static public int BurgerBullets = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(livesUIs != null){
            livesUIs[0].SetActive(true);
            livesUIs[1].SetActive(true);
            livesUIs[2].SetActive(true);
        }
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(friesUI != null){
           friesUI.text = "" + friesBullets;
           burgersUI.text = "" + BurgerBullets;
        }
        if(scoreUI != null){
           scoreUI.text = "" + kills;
        }
        if(coinsUI != null){
           coinsUI.text = "" + coinsCollected;
        }
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
            if(healthBar != null){
                healthBar.fillAmount = this.health / 6f;
            }
            if(this.health < 0)
                this.health = 0;
            if(this.lives > 0 && this.health == 0){
                FindObjectOfType<LevelManager>().RespawnPlayer();
                this.health = 6;
                if(healthBar != null){
                    healthBar.fillAmount = this.health / 6f;
                }
                if(livesUIs != null){
                    livesUIs[lives - 1].SetActive(false);
                }
                this.lives--;
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
    public void decreaseFries(){
        friesBullets-=1;
    }
    public void decreaseBurgers(){
        BurgerBullets-=1;
    }
    public void addFries(){
        if(friesBullets < 100){
            friesBullets+=(1 * coinsCollected / 6) ;
        }
        Debug.Log("Fries : " + friesBullets);
    }
    public void addBurger(){
        if(BurgerBullets < 100){
            BurgerBullets+=(1 * coinsCollected / 6);
        }
        Debug.Log("Burgers : " + BurgerBullets);

    }
    public int getBurgers(){return BurgerBullets;}
    public int getFries(){return friesBullets;}


}
