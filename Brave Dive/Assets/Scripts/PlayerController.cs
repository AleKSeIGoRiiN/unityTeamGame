using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 400.0f;
    public Camera cam; // ��������� ��� ������
    private Rigidbody2D _body; // ������ ��� ����

    Vector2 movement = Vector2.zero;// ������ ��������, �������� ������ � & y
    Vector2 mousePos = Vector2.zero;//�������� ������� ���� �� ����
    Vector2 movementVectors = Vector2.zero;
    Vector2 lookDir = Vector2.zero;

    //


    // 
    void Update()
    {
        float time;


        _body = GetComponent<Rigidbody2D>();// ������ ������ �������
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");//��������� ������� (������� � wasd)


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);// ������ - ������.��������� � ���������� (������� �����)
        lookDir = mousePos - _body.position;

        movementVectors = lookDir;
        movementVectors = movementVectors.normalized;




        if (movement.y < 0)
        {
            movementVectors.x = -movementVectors.x;
            movementVectors.y = -movementVectors.y;
            if (movement.x < 0)
            {
                time = movementVectors.x;
                movementVectors.x = movementVectors.x + movementVectors.y;
                movementVectors.y = movementVectors.y - time;
                movementVectors = movementVectors.normalized;
            }

            else if (movement.x > 0)
            {
                time = movementVectors.x;
                movementVectors.x = movementVectors.x - movementVectors.y;
                movementVectors.y += time;
                movementVectors = movementVectors.normalized;

            }

        }

        else if (movement.y > 0)
        {
            if (movement.x > 0)
            {
                time = movementVectors.x;
                movementVectors.x = movementVectors.x + movementVectors.y;
                movementVectors.y = movementVectors.y - time;
                movementVectors = movementVectors.normalized;
            }

            else if (movement.x < 0)
            {
                time = movementVectors.x;
                movementVectors.x = movementVectors.x - movementVectors.y;
                movementVectors.y += time;
                movementVectors = movementVectors.normalized;

            }

        }

        else if (movement.x < 0)
        {
            time = movementVectors.x;
            movementVectors.x = -movementVectors.y;
            movementVectors.y = time;

        }
        else if (movement.x > 0)
        {

            time = movementVectors.x;
            movementVectors.x = movementVectors.y;
            movementVectors.y = -time;

        }
        else if (movement.x == 0 && movement.y == 0)
        {
            movementVectors.x = 0;
            movementVectors.y = 0;
        }

        //#######################################################################################################################

        /*if (movement.x < 0 && movementVectors.y == 0)
        {
            time = movementVectors.x;
            movementVectors.x = -movementVectors.y;
            movementVectors.y = time;

        }
        else if (movement.x > 0 && movementVectors.y == 0) 
        {

            time = movementVectors.x;
            movementVectors.x = movementVectors.y;
            movementVectors.y = -time;

        }
        else if (movement.x == 0 && movement.y == 0)
        {
            movementVectors.x = 0;
            movementVectors.y = 0;
        }*/


    }

    void FixedUpdate()
    {



        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;   //� ����� ����� ����� ������ p.s. ���� ����� �� �������!
        _body.rotation = angle + 5f;






        _body.MovePosition(_body.position + movementVectors * speed * Time.fixedDeltaTime);//���� ��������� (���� ������, ����� ���� ���������� �� ���-�� ���)






    }
}

