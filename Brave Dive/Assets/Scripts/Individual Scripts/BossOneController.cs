using UnityEngine;
using System.Collections.Generic;

public class BossOneController : MonoBehaviour
{
   private List<Vector2> PathToMainPerson = new List<Vector2>();
   private PathFinder PathFinder;
   public GameObject MainPerson;
   public float MoveSpeed;
   public float StoppingDistance;
   private Rigidbody2D rb;

   [Range(0, 360)] public float ViewAngle = 360f;
   public float ViewDistance;
   public Transform EnemyEye;

   private bool view = false;
   private Animator Anim;
   private bool isMoving;
   private void Start()
   {
      MainPerson = GameObject.FindGameObjectWithTag("Player");
      Anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();
      PathFinder = GetComponent<PathFinder>();
      isMoving = true;
   }
   private void Update()
   {
      if (MainPerson == null) return;


      if (IsInView())
      {
         Vector2 lookDir = MainPerson.transform.position - transform.position;
         float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
         rb.rotation = angle + 100f;
      }
      if (Vector2.Distance(transform.position, MainPerson.transform.position) >= StoppingDistance &&
          Vector2.Distance(transform.position, MainPerson.transform.position) <= ViewDistance && view)
      {
         if (PathToMainPerson.Count == 0 && Vector2.Distance(transform.position, MainPerson.transform.position) > 0.5f)
         {
            PathToMainPerson = PathFinder.GetPath(MainPerson.transform.position);
            isMoving = true;
         }
         if (PathToMainPerson.Count == 0) return;
         if (isMoving)
         {
            if (Vector2.Distance(transform.position, PathToMainPerson[PathToMainPerson.Count - 1]) > 0.1f)
            {

               transform.position = Vector2.MoveTowards(transform.position, PathToMainPerson[PathToMainPerson.Count - 1], MoveSpeed * Time.deltaTime);
               Vector2 lookDir = MainPerson.transform.position - transform.position;
               float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
               rb.rotation = angle + 100f;
            }
            if (Vector2.Distance(transform.position, PathToMainPerson[PathToMainPerson.Count - 1]) <= 0.1f)
            {
               isMoving = false;
            }

         }
         else
         {
            PathToMainPerson = PathFinder.GetPath(MainPerson.transform.position);
            isMoving = true;
         }
           Anim.SetBool("running", isMoving);
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
         view = true;
         return true;
      }
      return false;
   }
}
