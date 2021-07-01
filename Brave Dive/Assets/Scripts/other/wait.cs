using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wait : MonoBehaviour
{
    public int waitTime;
    void Start()
    {
        StartCoroutine(WaitForLevel());
    }
    IEnumerator WaitForLevel(){

        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(2);
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(2);
        }
    }
}
