using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 15.0f;
    public Camera cam; // переменка для камеры

    private Rigidbody2D _body; // создаём под тело

    Vector2 movement = Vector2.zero;// вектор движений, содержит дельты х & y
    Vector2 mousePos = Vector2.zero;//Название говорит само за себя
    Vector2 movementVectors = Vector2.zero;
    Vector2 lookDir = Vector2.zero;

    //


    // 
    void Update()
    {
        speed = 15.0f;


        _body = GetComponent<Rigidbody2D>();// Делаем тельце твердым
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");//Принимает нажатия (стрелки и wasd)
        if (Math.Abs(movement.y) == Math.Abs(movement.x)) speed -= 3;


        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);// хаваем - камера.Перевести в координаты (позиция мышки)
        lookDir = mousePos - _body.position;





    }

    void FixedUpdate()
    {
        _body = GetComponent<Rigidbody2D>();


        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;   //А здесь чисто чуток матеши p.s. этот кусок не двигать!

        
        _body.rotation = angle - 22f;


        _body.MovePosition(_body.position + movement * speed * Time.fixedDeltaTime);//Само сдвижение (тайм фиксед, чтобы было независимо от кол-во фпс)






    }
}

