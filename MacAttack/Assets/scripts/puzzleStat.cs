using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class puzzleStat : MonoBehaviour
{
    private int points = 0;
    public TextMeshProUGUI timerUI;
    public TextMeshProUGUI puzzleUI;
    private float timer = 90f;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    
    public AudioClip victoryAudio;

    // Update is called once per frame
    void Update()
    {
        if(points == 9){
            victoryScreen.SetActive(true);
        }
        timer = timer - Time.deltaTime;
        if(timer <= 10f){
            timerUI.text = "<color=\"red\">" + (Mathf.Round(timer)/100);
        }else{
            timerUI.text = "" + (Mathf.Round(timer)/100);
        }
        if(timer <= 0){
            AudioManager.instance.RandomizeSFX(victoryAudio);
            gameOverScreen.SetActive(true);         
            Time.timeScale=0;
        }
    }
    public void addPoint(){
        points += 1;
        puzzleUI.text = "" + points + "/9";

    }
}
