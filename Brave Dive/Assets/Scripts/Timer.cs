using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour
{
    public static float timerMinutes = 0f;
    public static float timerSeconds = 0f;
    public string timer = timerMinutes.ToString() + " : " + timerSeconds.ToString();
    public Text timerText;




    void Start()
    {
        timerText.text = timer;
   
    }

    void checkTime()
    {
        if (Mathf.Round(timerSeconds) <= 9)
        {
            timer = "0" + Mathf.Round(timerMinutes).ToString() + " : 0" + Mathf.Round(timerSeconds).ToString();
        }else{
            timer = "0" + Mathf.Round(timerMinutes).ToString() + " : " + Mathf.Round(timerSeconds).ToString();
        }
       
        if (Mathf.Round(timerSeconds) == 60)
        {
            timerSeconds = 0f;
            timerMinutes += 1;
        }
    }

    void Update()
    {
        timerSeconds += Time.deltaTime;
        checkTime();
        timerText.text = timer;
      
    }

    /*

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
    
    */
}
