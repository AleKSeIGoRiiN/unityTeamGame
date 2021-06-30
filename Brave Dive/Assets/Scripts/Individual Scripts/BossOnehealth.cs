using UnityEngine;

public class BossOnehealth : MonoBehaviour
{
   [Header("Health")]
   public int MaxHealth;
   private int currentHealth;

   [SerializeField] private HeathBar _heathBar;
   [SerializeField] private AudioSource DieEnemy;
   [SerializeField] private AudioSource HitEnemy;

   private void Start()
   {
      currentHealth = MaxHealth;
      _heathBar.SetHeathValue(currentHealth, MaxHealth);
   }
   void Die()
   {
      Destroy(gameObject, 0.5f);
   }
   public void TakeDamage(int damage)
   {
      //HitEnemy.Play();
      currentHealth -= damage;
      _heathBar.SetHeathValue(currentHealth, MaxHealth);
      if (currentHealth <= 0)
      {
         //DieEnemy.Play();
         Die();
      }
   }
}