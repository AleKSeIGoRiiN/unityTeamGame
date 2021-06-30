using UnityEngine;
using System.Collections.Generic;

public class enemyHardControl : MonoBehaviour
{
   public GameObject MainPerson;
   private Rigidbody2D rb;
   [Range(0, 360)] public float ViewAngle = 360f;
   public float ViewDistance;
   public Transform EnemyEye;


   private Animator Anim;
   private bool isMoving;
   private void Start()
   {
      MainPerson = GameObject.FindGameObjectWithTag("Player");
      Anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
   }
   private void Update()
   {
      if (MainPerson == null) return;


      if (IsInView())
      {
         Vector2 lookDir = MainPerson.transform.position - transform.position;
         float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
         rb.rotation = angle + 90f;
      }
      else return;

   }

   public bool IsInView()
   {
      float realAngle = Vector3.Angle(EnemyEye.forward, MainPerson.transform.position - EnemyEye.position);
      RaycastHit2D hit = Physics2D.Raycast(EnemyEye.transform.position, MainPerson.transform.position - EnemyEye.position, ViewDistance);
      if (realAngle < ViewAngle / 2f && Vector3.Distance(EnemyEye.position, MainPerson.transform.position) <= ViewDistance &&
         hit.transform.position == MainPerson.transform.position)
      {
         return true;
      }
      return false;
   }
}
