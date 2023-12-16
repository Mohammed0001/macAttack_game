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
                                 "Congratulations! Ronald You Have Reached the Map Of the Recipe.\n Take Care in your Adventure you only have: 3 lives which is the Sundae Above",
                                 "Now, You have to follow the Instructions to get the Recipe back from the burger king.\n Don't Worry you will find Hamburglar and Grimace to help you.",
                                 "First, You Have to collect some Ingredients: \n Buns \n Beef \n  Lettece \n  Tomatos \n  Pickles \n  onions ",
                                 "As much Ingredients you collect as much weapons you will have in the battle",
                                 "Then, You Also have to collect some weapons to fight the burger army and the Burger King: \n 15 - Burgers \n 18 - fries ",
                                 "Finally, You Have to fight the burger king and get the recipe from him but take care he could try to make you a part from his team."
                };

                dialogueManager.SetSentences(dialogue);
                dialogueManager.StartCoroutine(dialogueManager.TypeDialogue());
                alreadyPlayed = true;
            }

        }
    }
}
