
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
   [Header("Health")]
   public int MaxHealth;
   private int currentHealth;
   [SerializeField] private HeathBar _heathBar;

    [SerializeField] private AudioSource dieEnemy;
    [SerializeField] private AudioSource hitEnemy;

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
      Debug.Log("www");
      currentHealth -= damage;
      _heathBar.SetHeathValue(currentHealth, MaxHealth);
        hitEnemy.Play();

      if (currentHealth <= 0)
      {
            dieEnemy.Play();
            Die();
      }
   }
}
