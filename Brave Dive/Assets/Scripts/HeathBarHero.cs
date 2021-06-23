using UnityEngine;
using UnityEngine.UI;

public class HeathBarHero : MonoBehaviour
{
   [SerializeField] private Slider SliderLeft;
   [SerializeField] private Slider SliderRight;

   public void SetHeathValue(int currentHealth, int maxHeath)
   {
      SliderLeft.value = currentHealth;
      SliderLeft.maxValue = maxHeath;
      SliderRight.value = currentHealth;
      SliderRight.maxValue = maxHeath;
   }
}
