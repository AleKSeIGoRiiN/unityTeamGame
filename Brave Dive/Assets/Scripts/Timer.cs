using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public static float timerMinutes = 0f;
    public static float timerSeconds = 0f;
    public string timer = timerMinutes.ToString() + " : " + timerSeconds.ToString();
    public Text timerText; 


    void Start()
    {
        timerText.text = timer;
    }

    void checkTime()
    {
        if (Mathf.Round(timerSeconds) <= 9)
        {
            timer = "0" + Mathf.Round(timerMinutes).ToString() + " : 0" + Mathf.Round(timerSeconds).ToString();
        }else{
            timer = "0" + Mathf.Round(timerMinutes).ToString() + " : " + Mathf.Round(timerSeconds).ToString();
        }
       
        if (Mathf.Round(timerSeconds) == 60)
        {
            timerSeconds = 0f;
            timerMinutes += 1;
        }
    }

    void Update()
    {
        timerSeconds += Time.deltaTime;
        checkTime();
        timerText.text = timer;
    }
}
