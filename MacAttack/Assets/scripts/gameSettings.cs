using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gameSettings : MonoBehaviour
{
    public GameObject PauseScreen;
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public static bool paused;
    public KeyCode PauseButton;
    // Start is called before the first frame update
    void Start()
    {
        paused=false;
        PauseScreen.SetActive(false);
       // gameOverScreen.SetActive(false);
        //victoryScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
        if(Input.GetKeyDown(PauseButton)){
            Pause();
        }
        else if(Input.GetKeyDown(PauseButton)&&paused)
        {
            Resume();
        }
        
    }
    public void nextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void startGame(){
        SceneManager.LoadScene(1);
    }
    public void reStartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1;
    }
    public void quitGame(){
        Application.Quit();
    }
    void Pause(){
        PauseScreen.SetActive(true);
        paused=true;
        Time.timeScale=0;
    }
    public void Resume(){
        PauseScreen.SetActive(false);
        paused=false;
        Time.timeScale=1;
    }
}
