using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int numberSpots;

    private Rigidbody2D rb;

    void Start(){
        numberSpots = 0;
        waitTime = startWaitTime;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[numberSpots].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[numberSpots].position)< 0.2f){
            if(waitTime <= 0){
                rb.rotation += 180f;
                waitTime = startWaitTime;
                if(numberSpots == 0) numberSpots = 1;
                else numberSpots = 0;

            }else{
                waitTime -= Time.deltaTime;
            }
        }
    }
}
