using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewRecipeD : MonoBehaviour
{
    public Dialogue dialogueManager;
    private object other;
    public bool alreadyPlayed = false;

    //Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
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
                                    "You Have to collect some Ingredients \n n - Buns \n n - Burgers \n n - Lettece \n n - Tomatos \n n - Chease \n n - Beacons \n n - onions ",
                                 "You Also have to collect some weapons to fight the burger army and the Burger King \n ",
                                 "Hamburglar: Of course! You'll need bread, onion, beef, tomatoes, pickles, and lettuce. But be careful, okay?",
                                 "Ronald McDonald: Thanks! What do I need to watch out for?",
                                 "Hamburglar: Pay attention to only collect the right ingredience  no mistakes. And avoid boiling oil and spoiled ketchup!",
                                 "Ronald McDonald: Got it! Thanks for the warning, friend!"
            };

                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
                alreadyPlayed = true;
            }

        }
    }
}
