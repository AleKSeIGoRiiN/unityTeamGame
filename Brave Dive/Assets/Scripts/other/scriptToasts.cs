using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptToasts : MonoBehaviour
{
   public GameObject[] toasts;
   public GameObject Space;

   private int i;


   void Start()
   {
      i = 0;
      toasts[i].SetActive(true);
      Space.SetActive(true);
      gameObject.SetActive(true);
   }


   void Update()
   {
       if(gameObject.activeInHierarchy){
           Time.timeScale = 0f;
       }
      
         if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.KeypadEnter))
         {
            toasts[i].SetActive(false);
            i++;
            if (i < toasts.Length) toasts[i].SetActive(true);

            else{
                gameObject.SetActive(false);
                Space.SetActive(false);
                Time.timeScale = 1f;
            }

         }
      
   }
}
