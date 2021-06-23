
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
   [Header("Health")]
   public int MaxHealth = 3;
   private int currentHealth;
   [SerializeField] private HeathBar _heathBar;

   private void Start()
   {
      currentHealth = MaxHealth; 
      _heathBar.SetHeathValue(currentHealth, MaxHealth);
   }
   void Die()
   {
      Destroy(gameObject);
   }
   public void TakeDamage(int damage)
   {
      currentHealth -= damage;
      _heathBar.SetHeathValue(currentHealth, MaxHealth);

      if (currentHealth <= 0)
      {
         Die();
      }
   }
}
