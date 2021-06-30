using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
   [Header("Health")]
   public int MaxHealth;
   private int currentHealth;
   public playerInteraction player;

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
      enemyCount.enemys += 1;
      Destroy(gameObject, 0.5f);
      if(player.MaxHealth - player.currentHealth >= 10 ){
         player.currentHealth += 5;
      }
   }
   public void TakeDamage(int damage)
   {
      HitEnemy.Play();
      currentHealth -= damage;
      _heathBar.SetHeathValue(currentHealth, MaxHealth);
      if (currentHealth <= 0)
      {
         DieEnemy.Play();
         Die();
      }
   }
}
