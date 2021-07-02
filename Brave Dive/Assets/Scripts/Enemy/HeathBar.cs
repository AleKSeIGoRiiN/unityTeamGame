using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
   [SerializeField] private Slider _slider;
   [SerializeField] private Vector3 _offset;

   public GameObject Boss;

   private void Update()
   {
      if(Boss == null) _slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + _offset);
   }

   public void SetHeathValue(int currentHealth, int maxHeath)
   {
      _slider.gameObject.SetActive(currentHealth < maxHeath);
      _slider.value = currentHealth;
      _slider.maxValue = maxHeath;
   }
}
