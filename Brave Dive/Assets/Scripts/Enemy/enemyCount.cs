using UnityEngine;
using UnityEngine.UI;

public class enemyCount : MonoBehaviour
{
   public Text count;
   public Text notice;
   public GameObject door;
   public static int enemys;

   void Start()
   {
      enemys = 0;
      if (count != null)
      {
         count.text = enemys.ToString();
      }

   }

   void Update()
   {
      if (count != null)
      {
         count.text = enemys.ToString();
         if (count.text == "45" && door != null)
         {
            Destroy(door);
            if (notice != null) notice.gameObject.SetActive(true);
            Destroy(notice, 3f);
         }
      }
   }
}
