using UnityEngine;

public class BulletScript : MonoBehaviour
{
   public GameObject MainPerson;
   public int damage;
   private Rigidbody2D rb;
   void Start()
   {
      MainPerson = GameObject.FindGameObjectWithTag("Player");
      rb = GetComponent<Rigidbody2D>();
   }
   void update()
   {
      Vector2 lookDir = MainPerson.transform.position - transform.position;
      float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
      rb.rotation = angle;
   }
   private void OnCollisionEnter2D(Collision2D collision)
   {
      Destroy(gameObject);
      collision.gameObject.GetComponent<playerInteraction>().TakeDamage(damage);
   }
}
