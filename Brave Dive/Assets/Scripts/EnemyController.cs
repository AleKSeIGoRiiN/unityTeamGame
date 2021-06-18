using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //private Rigidbody2D physic;

    public Transform player;

    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

   // public float agroDistance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
       // physic = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && (Vector2.Distance(transform.position, player.position)> retreatDistance))
        {
            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
        /*
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroDistance)
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }

        void StartHunting()
        {
            if(player.position.x < transform.position.x && player.position.y < transform.position.y)
            {
                physic.velocity = new Vector2(-speed, -speed);
            }
            if (player.position.x < transform.position.x && player.position.y > transform.position.y)
            {
                physic.velocity = new Vector2(-speed, speed);
            }
            if (player.position.x > transform.position.x && player.position.y < transform.position.y)
            {
                physic.velocity = new Vector2(speed, -speed);
            }
            if (player.position.x > transform.position.x && player.position.y > transform.position.y)
            {
                physic.velocity = new Vector2(speed, speed);
            }
        }
        void StopHunting()
        {
            physic.velocity = new Vector2(0, 0);
        }
        */
    }
}
