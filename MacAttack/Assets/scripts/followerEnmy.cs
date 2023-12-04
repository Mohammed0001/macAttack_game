using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followerEnmy : EnemyController
{
    public int speedtowardplayer; 
    private controller player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<controller>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,player.transform.position,speedtowardplayer*Time.deltaTime);
    }
}
