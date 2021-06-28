using UnityEngine;
using UnityEngine.SceneManagement;
public class playerInteraction : MonoBehaviour
{
   public int MaxHealth = 100;
   public int currentHealth;
   public GameObject dieMenu;
   [SerializeField] private HeathBarHero HeathBarHero;
   [SerializeField] private AudioSource diePlayer;

   private void Start()
   {
      currentHealth = MaxHealth;
      HeathBarHero.SetHeathValue(currentHealth, MaxHealth);
   }
   public void Die()
   {
      //SceneManager.LoadScene(0);
      dieMenu.SetActive(true);
      Time.timeScale = 0f;
      diePlayer.Play(); 
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
