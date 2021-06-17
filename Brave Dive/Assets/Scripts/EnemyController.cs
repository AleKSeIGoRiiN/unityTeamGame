using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D physic;

    public Transform player;

    public float speed;
    public float agroDistance;

    private void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
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
    }
}
