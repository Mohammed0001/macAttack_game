using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class grimacedialogue : MonoBehaviour
{
    public Dialogue dialogueManager;
    private object other;
    public bool alreadyPlayed = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!alreadyPlayed)
            {
                string[] dialogue = {
                                 "Ronald McDonald: Hello Grimace! .. Can you help me to collect weapons for my battle?",
                                 "Grimace: Of course! ... How Can I help you?",
                                 "Ronald McDonald: Can you tell me what kind of weapons should I collect?",
                                 "Grimace: Sure! .. Collect Mac Fries and Burgers",
                                 "Grimace: Ohh!! .. I forgot to tell you .. don't collect Fried Chicken and Tahini also be careful .. this road is full of obstacles",
                                 "Ronald McDonald: Okay .. Thank you!"
            };

                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
                alreadyPlayed = true;
            }

            }
    }
}
