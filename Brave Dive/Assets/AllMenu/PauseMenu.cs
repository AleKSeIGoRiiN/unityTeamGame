using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    [SerializeField] private AudioSource TimeOut;

    void Update() //вкл выкл паузы на ескейп
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
                TimeOut.Play();
            }
        }
    }

    public void Resume() //продолжение
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause() //пауза
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LoadMenu() //выход в меню
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
