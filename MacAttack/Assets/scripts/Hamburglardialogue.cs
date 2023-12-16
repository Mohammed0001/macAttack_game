using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hamburglardialogue : MonoBehaviour
{
    public Dialogue dialogueManager;
    private object other;


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
                string[] dialogue = {"Hamburglar: Hey Ronald, how's it going?",
                                 "Ronald McDonald: Good! I just need help for collecting Big Mac ingredients. Can you help me?",
                                 "Hamburglar: Of course! You'll need bread, onion, beef, tomatoes, pickles, and lettuce. But be careful, okay?",
                                 "Ronald McDonald: Thanks! What do I need to watch out for?",
                                 "Hamburglar: Pay attention to only collect the right ingredience  no mistakes. And avoid boiling oil and spoiled ketchup!",
                                 "Ronald McDonald: Got it! Thanks for the warning, friend!"};

            dialogueManager.SetSentences(dialogue);
            dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());

        }

    }
}

