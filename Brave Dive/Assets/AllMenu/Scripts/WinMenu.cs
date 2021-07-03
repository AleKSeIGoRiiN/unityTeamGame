using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void BackMenu() //����� � ����
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Restart() //���������� ����
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    /* winMenu.SetActive(true);
         Time.timeScale = 0f;*/

    /*public GameObject winMenu;*/
}
