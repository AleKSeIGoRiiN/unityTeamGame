using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieMenu : MonoBehaviour
{
 
    /*void Update()
    {
        
    }*/

    public void BackMenu() //выход в меню
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Restart() //перезапуск игры
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }
}
