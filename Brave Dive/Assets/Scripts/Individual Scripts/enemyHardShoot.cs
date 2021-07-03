using UnityEngine;
using System.Collections;
public class enemyHardShoot : MonoBehaviour
{
   Vector2 Direction;
   [Range(0, 360)] public float ViewAngle;
   public float ViewDistance;
   public Transform EnemyEye;
   public Transform Target;
   public GameObject Bullet;
   public Transform ShootPointOne;
   public Transform ShootPointTwo;
   float nextTimeFire = 3;
   public float Force;
   public float FireRate;

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
            ShootTwo();
            ShootOne();
         }
      }
   }
   void ShootOne()
   {
      GameObject BulletInOne = Instantiate(Bullet, ShootPointOne.position, Quaternion.identity);
      BulletInOne.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
      // gunShot.Play(); //���� ��������
   }
   IEnumerator ShootTwo()
   {
      yield return new WaitForSeconds(1f);
      GameObject BulletInTwo = Instantiate(Bullet, ShootPointTwo.position, Quaternion.identity);
      BulletInTwo.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
     // gunShot.Play(); //���� ��������
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
