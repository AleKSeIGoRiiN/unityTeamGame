using UnityEngine;

public class EnemeShooting : MonoBehaviour
{
    public float Range;
    Vector2 Direction;

    public Transform Target;
    public GameObject Bullet;
    public Transform ShootPoint;

    public float FireRate;
    float nextTimeFire = 0;
    public float Force;

    bool Detected = false;

    [SerializeField] private AudioSource gunShot;
    private void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos = (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {
                if(Detected == false)
                {
                    Debug.Log("Da");
                    Detected = true;
                }
            }
        }
        else
        {
            if (Detected == true)
            {
                Debug.Log("Net");
                Detected = false;
            }
        }
        if (Detected)
        {
          
        }
    }
    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);

        gunShot.Play(); //звук стрельбы
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
