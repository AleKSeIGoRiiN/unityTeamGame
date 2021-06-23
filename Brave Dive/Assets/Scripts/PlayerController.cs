using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed;
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
        speed = 10f;

        _body = GetComponent<Rigidbody2D>();// ������ ������ �������
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");//��������� ������� (������� � wasd)
        if (Math.Abs(movement.y) == Math.Abs(movement.x)) speed -= 3;


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);// ������ - ������.��������� � ���������� (������� �����)
        lookDir = mousePos - _body.position;

    }

    void FixedUpdate()
    {
        _body = GetComponent<Rigidbody2D>();

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;   //� ����� ����� ����� ������ p.s. ���� ����� �� �������!

        _body.rotation = angle - 22f;

        _body.MovePosition(_body.position + movement * speed * Time.fixedDeltaTime);//���� ��������� (���� ������, ����� ���� ���������� �� ���-�� ���)


    }
}

