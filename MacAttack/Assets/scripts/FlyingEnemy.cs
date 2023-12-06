using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float amplitude;

    private Vector3 temp_position;

    public float moveSpeed;

    private controller Player;

    void Start()
    {
        temp_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        temp_position.x += HorizontalSpeed;
        temp_position.y += Mathf.Sin(Time.realtimeSinceStartup*VerticalSpeed) * amplitude;
        transform.position = temp_position;
    }
}
