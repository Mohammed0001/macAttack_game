using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class cutSceneManger : MonoBehaviour
{

    public float waitTime= 5;
    void Start()
    {
        StartCoroutine(wait());    
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(1);
    }

}
