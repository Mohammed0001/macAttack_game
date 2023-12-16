using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle : MonoBehaviour
{
    public GameObject correctPlace;
    private bool movingObject;
    private float startPositionX;
    private float startPositionY;

    private Vector3 resetPosition;
    
    public AudioClip correct;
    public AudioClip inCorrect;


    private bool finish ;
    void Start()
    {
        resetPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(movingObject && finish == false){
            Vector3 mousePosition;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.localPosition = new Vector3(mousePosition.x - startPositionX , mousePosition.y - startPositionY , transform.localPosition.z);
        }
    }
    private void OnMouseDown(){
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePosition;
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            startPositionX = mousePosition.x - transform.localPosition.x;
            startPositionY = mousePosition.y - transform.localPosition.y;
            movingObject = true;
        }
    }
    private void OnMouseUp(){
        movingObject = false;
        if((Mathf.Abs(this.transform.position.x - correctPlace.transform.position.x) <= 0.5f) && (Mathf.Abs(this.transform.position.y - correctPlace.transform.position.y) <= 0.5f) )
        {
            transform.position = new Vector3(correctPlace.transform.position.x , correctPlace.transform.position.y , correctPlace.transform.position.z );
            finish = true;
            AudioManager.instance.RandomizeSFX(correct);
            FindObjectOfType<puzzleStat>().addPoint();
        }
        else{
            transform.localPosition = new Vector3(resetPosition.x , resetPosition.y , resetPosition.z);
            AudioManager.instance.RandomizeSFX(inCorrect);

        }
    }
}
