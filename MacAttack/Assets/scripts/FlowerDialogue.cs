using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerDialogue : MonoBehaviour
{
    public Dialogue dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Player")
        {
            string[] dialogue = { "Oh, absolutely, Ronald! I'm always ready for an adventure. What are we looking for?" , 
                                "The Pickle of Flavors and the Cheese of Wonder? That sounds like a challenge. Where should we start?" , "I'll check the kitchen! You look around the living room.",
                                "As Ronald and Grimace search, they discover a trail of pickles leading to the backyard." };
            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
        }
    }
}
