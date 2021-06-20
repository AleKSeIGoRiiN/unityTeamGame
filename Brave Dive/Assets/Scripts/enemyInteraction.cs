using UnityEngine;

public class enemyInteraction : MonoBehaviour
{
    private float timeBtwShots;
    public float startTimeBtwShots;

    private float health = 100f;
    private float damage = 5f;




    public GameObject projectile;
    public Transform player;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        
        if (timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
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
