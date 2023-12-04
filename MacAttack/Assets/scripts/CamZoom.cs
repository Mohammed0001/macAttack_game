using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    private Camera cam;
    public float ZoomSpeed;
    public KeyCode zbutton;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(zbutton)){
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize , 4, Time.deltaTime * ZoomSpeed);
        }else{
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize , 6, Time.deltaTime * ZoomSpeed);

        }
    }
}
 