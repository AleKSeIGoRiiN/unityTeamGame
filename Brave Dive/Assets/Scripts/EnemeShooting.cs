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

    private void Update()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;

        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);

        if (rayInfo)
        {
            if(rayInfo.collider.gameObject.tag == "Player")
            {
                Debug.Log("aaa");
            }
            if (Vector2.Distance(transform.position, Target.position) <= Range)
            {
                Detected = true;
            }
        }
        else
        {
            if (Detected == true)
            {
                Detected = false;
            }
        }
        if (Detected)
        {
          if(Time.time > nextTimeFire)
            {
                nextTimeFire = Time.time + 1 / FireRate;
                Shoot();
            }
        }
    }
    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force); 
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }
}
