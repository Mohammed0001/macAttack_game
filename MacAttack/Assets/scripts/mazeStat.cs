using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class mazeStat : MonoBehaviour
{
    public TextMeshProUGUI timerUI;
    private float timer = 60f;
    public GameObject victoryScreen;
    public GameObject gameOverScreen;
    // Update is called once per frame
    void Update()
    {
        timer = timer - Time.deltaTime;
        timerUI.text = "" + (Mathf.Round(timer)/100);
        if(timer <= 0){
            gameOverScreen.SetActive(true);
            Time.timeScale=0;
        }
    }
    public void vicroty(){
        victoryScreen.SetActive(true);
        Time.timeScale=0;
    }
}
