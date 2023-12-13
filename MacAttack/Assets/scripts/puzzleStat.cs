using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleStat : MonoBehaviour
{
    private int points = 0;
    public GameObject victoryScreen;

    // Update is called once per frame
    void Update()
    {
        if(points == 9){
            victoryScreen.SetActive(true);
        }
    }
    public void addPoint(){
        points += 1;
    }
}
