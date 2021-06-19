using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float health = 100f;
    private float damage = 5f;

    public Transform player;
    private Rigidbody2D rb;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public GameObject[] gameObjects;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       

    }
    private void Update()
    {

        rb = GetComponent<Rigidbody2D>();
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position)> retreatDistance))
        {
            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

      
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = player.position - transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;   //А здесь чисто чуток матеши
        rb.rotation = angle;
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
