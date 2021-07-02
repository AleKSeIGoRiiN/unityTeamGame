using UnityEngine;
using System.Collections;
public class BossOnehealth : MonoBehaviour
{
   [Header("Health")]
   public int MaxHealth;
   private int currentHealth;

   public GameObject winMenu;

   [SerializeField] private HeathBar _heathBar;
   [SerializeField] private AudioSource DieEnemy;
   [SerializeField] private AudioSource HitEnemy;

   private void Start()
   {
      currentHealth = MaxHealth;
      _heathBar.SetHeathValue(currentHealth, MaxHealth);
   }
   IEnumerator Die()
   {
      yield return new WaitForSeconds(3f);
      winMenu.SetActive(true);
      Destroy(gameObject, 3f);
   }
   public void TakeDamage(int damage)
   {
      //HitEnemy.Play();
      currentHealth -= damage;
      _heathBar.SetHeathValue(currentHealth, MaxHealth);
      if (currentHealth <= 0)
      {
         //DieEnemy.Play();
         Time.timeScale = 0f;
         StartCoroutine(Die());
      }
   }
}