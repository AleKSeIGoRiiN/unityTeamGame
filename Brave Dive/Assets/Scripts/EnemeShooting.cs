using UnityEngine;

public class EnemeShooting : MonoBehaviour
{
   Vector2 Direction;
   [Range(0, 360)] public float ViewAngle;
   public float ViewDistance;
   public Transform EnemyEye;

   public Animator animator;
   public Transform Target;
   public GameObject Bullet;
   public Transform ShootPoint;

   public float FireRate;
   float nextTimeFire = 0;
   public float Force;

   bool Detected = false;
   [SerializeField] private AudioSource gunShot;

   private void Start()
   {
      Target = GameObject.FindGameObjectWithTag("Player").transform;
   }
   private void Update()
   {
      Vector2 targetPos = Target.position;
      Direction = targetPos - (Vector2)transform.position;

      if (Vector2.Distance(transform.position, Target.position) <= ViewDistance && IsInView())
      {
         Detected = true;
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
      animator.SetTrigger("Shoot");
      GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
      BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
      gunShot.Play(); //���� ��������
   }
   void OnDrawGizmosSelected()
   {
      Gizmos.DrawWireSphere(transform.position, ViewDistance);
   }
   public bool IsInView()
   {
      float realAngle = Vector3.Angle(EnemyEye.forward, Target.position - EnemyEye.position);
      RaycastHit2D hit = Physics2D.Raycast(EnemyEye.transform.position, Target.position - EnemyEye.position, ViewDistance);
      if (realAngle <= ViewAngle / 2f && Vector2.Distance(EnemyEye.position, Target.position) <= ViewDistance &&
         hit.transform.position == Target.position)
      {
         return true;
      }return false;
   }
}
