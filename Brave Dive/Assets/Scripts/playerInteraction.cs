using UnityEngine;
using UnityEngine.SceneManagement;
public class playerInteraction : MonoBehaviour
{
   public int MaxHealth = 100;
   public int currentHealth;
   [SerializeField] private HeathBarHero HeathBarHero;
   [SerializeField] private AudioSource diePlayer;

   private void Start()
   {
      currentHealth = MaxHealth;
      HeathBarHero.SetHeathValue(currentHealth, MaxHealth);
   }
   void Die()
   {
      diePlayer.Play(); //������
      Destroy(gameObject);
      SceneManager.LoadScene(0);
   }

   public void TakeDamage(int damage)
   {
      currentHealth -= damage;
      HeathBarHero.SetHeathValue(currentHealth, MaxHealth);
      if (currentHealth <= 0)
      {
         Die();
      }
   }
}
