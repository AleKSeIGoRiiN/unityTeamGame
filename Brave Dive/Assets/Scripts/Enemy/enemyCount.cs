using UnityEngine;
using UnityEngine.UI;

public class enemyCount : MonoBehaviour
{
   public Text count;
   public Text notice;
   public GameObject door;
   public static int enemys;

   void Update()
   {
      if (count != null)
      {
         count.text = enemys.ToString();
         if (count.text == "45")
         {
            Destroy(door);
            notice.gameObject.SetActive(true);
            Destroy(notice, 3f);
         }
      }
   }
}
