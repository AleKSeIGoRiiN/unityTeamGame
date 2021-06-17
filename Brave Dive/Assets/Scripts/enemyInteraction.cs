using UnityEngine;

public class enemyInteraction : MonoBehaviour
{
    
    private float health = 1f;
    private float damage = 0.25f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "MainPerson")
        {
            collision.GetComponent<playerInteraction>().takeDamage(damage);
        }
    }

    public void takeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }

        void Die()
        {
            Destroy(gameObject);
        }
    }
}
