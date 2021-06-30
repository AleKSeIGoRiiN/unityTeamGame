using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

   public Animator animator;
   public Transform attackPoint;
   public float attackRange = 200.0f;
   public LayerMask enemyLayers;

   public float attackRate = 2f;
   float nextAttack = 0f;



   [SerializeField] private AudioSource missAttack;
   [SerializeField] private AudioSource attackEnemy;


   void Update()
   {
      if (Time.time >= nextAttack)
      {
         if (Input.GetMouseButton(0))
         {
            nextAttack = Time.time + 1f / attackRate;
            Attack();
         }
      }

   }
   void Attack()
   {
      animator.SetTrigger("Attack");
      Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        if (hitEnemies.Length == 0) missAttack.Play();
        else attackEnemy.Play();
        foreach (Collider2D enemy in hitEnemies)
      {
         if( enemy.GetComponent<HealthEnemy>() != null) enemy.GetComponent<HealthEnemy>().TakeDamage(1);
         if( enemy.GetComponent<BossOnehealth>() != null) enemy.GetComponent<BossOnehealth>().TakeDamage(1);

      }
     /* if (hitEnemies.Length == 0) missAttack.Play();
      else attackEnemy.Play();*/
   }
}
