using UnityEngine;
using UnityEngine.SceneManagement;

public class playerInteraction : MonoBehaviour
{
    [SerializeField]
    private float health = 1f;

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    } 
    private void Die()
    {
        SceneManager.LoadScene(0);
    }
}
