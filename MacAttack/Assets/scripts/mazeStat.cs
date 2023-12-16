using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class mazeStat : MonoBehaviour
{
    public TextMeshProUGUI timerUI;
    public AudioClip victoryAudio;
    private float timer = 90f;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    


    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        if(timer <= 10f){
            timerUI.text = "<color=\"red\">" + (Mathf.Round(timer)/100);
        }else{
            timerUI.text = "" + (Mathf.Round(timer)/100);
        }
        if(timer <= 0){
            gameOverScreen.SetActive(true);
            Time.timeScale=0;
        }
        // if(timer <= 50f){
        //     timerUI.color = new Color(100,10,10,1) ;
        // }
    }
    public void vicroty(){
        victoryScreen.SetActive(true);
        AudioManager.instance.RandomizeSFX(victoryAudio);
        Time.timeScale=0;
    }
}
