using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    [SerializeField] private AudioSource TimeOut;

    void Update() //��� ���� ����� �� ������
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

    public void Resume() //�����������
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause() //�����
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LoadMenu() //����� � ����
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
