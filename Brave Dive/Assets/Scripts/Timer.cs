using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
   public playerInteraction Health;
   public static float timerMinutes = 0f;
   public static float timerSeconds = 0f;
   public string timerStart = timerMinutes.ToString() + " : " + timerSeconds.ToString();
   public string timer = timerMinutes.ToString() + " : " + timerSeconds.ToString();
   public Text timerText;


   void Start()
   {
      timerText.text = timerStart;
      timerText.gameObject.SetActive(true);
   }

   void checkTime()
   {
      if (Mathf.Round(timerSeconds) <= 9)
      {
         timer = "0" + Mathf.Round(timerMinutes).ToString() + " : 0" + Mathf.Round(timerSeconds).ToString();
      }
      else
      {
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
      if (Health.currentHealth <= 0)
      {
         timerMinutes = 0f;
         timerSeconds = 0f;
         timer = timerStart;
      }
      timerSeconds += Time.deltaTime;
      checkTime();
      timerText.text = timer;
   }
}
