using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
    private List<Vector2> PathToMainPerson = new List<Vector2>();
    private PathFinder PathFinder;
    public GameObject MainPerson;
    public float MoveSpeed;


    private bool isMoving;
    private void Start()
    {
   
        PathFinder = GetComponent<PathFinder>();
        isMoving = true;
    }
    private void Update()
    {
        if (MainPerson == null) return;
        if (Vector2.Distance(transform.position, MainPerson.transform.position) >= 5f &&
             Vector2.Distance(transform.position, MainPerson.transform.position) <= 10f)
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
        }
        else return;
        
    }
}