using UnityEngine;

public class enemyShootingRoof : MonoBehaviour
{
   Vector2 Direction;
   [Range(0, 360)] public float ViewAngle;
   public float ViewDistance;
   public Transform EnemyEye;

   public Animator animator;
   public Transform Target;
   public GameObject Bullet;
   public Transform ShootPoint;
   private Rigidbody2D rb;

   public float FireRate;
   float nextTimeFire = 0;
   public float Force;

   bool Detected = false;
   [SerializeField] private AudioSource gunShot;

   private void Start()
   {
      Target = GameObject.FindGameObjectWithTag("Player").transform;
       rb = GetComponent<Rigidbody2D>();
   }
   private void Update()
   {
      Vector2 targetPos = Target.position;
      Direction = targetPos - (Vector2)transform.position;

      if (Vector2.Distance(transform.position, Target.position) <= ViewDistance)
      {
         Detected = true;
         Vector2 lookDir = Target.position - transform.position;
         float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
         rb.rotation = angle;
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
         if (Time.time > nextTimeFire)
         {
            nextTimeFire = Time.time + 1 / FireRate;
            Shoot();
         }
      }
   }
   void Shoot()
   {
      //animator.SetTrigger("Shoot");
      GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
      BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
     // gunShot.Play(); //���� ��������
   }
   void OnDrawGizmosSelected()
   {
      Gizmos.DrawWireSphere(transform.position, ViewDistance);
   }

}