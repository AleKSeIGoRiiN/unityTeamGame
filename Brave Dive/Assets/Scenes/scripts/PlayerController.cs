using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 400.0f;
    public Camera cam; // переменка для камеры
    private Rigidbody2D _body; // создаём под тело

    Vector2 movement;// вектор движений, содержит дельты х & y
    Vector2 mousePos;//Название говорит само за себя

    //

    
    // 
    void Update()
    {
        _body = GetComponent<Rigidbody2D>();// Делаем тельце твердым
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");//Принимает нажатия (стрелки и wasd)
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);// хаваем - камера.Перевести в координаты (позиция мышки)

    }
    
    void FixedUpdate()
    {
        _body.MovePosition(_body.position + movement * speed * Time.fixedDeltaTime);//Само сдвижение (тайм фиксед, чтобы было независимо от кол-во фпс)

        
        Vector2 lookDir = mousePos - _body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;   //А здесь чисто чуток матеши
        _body.rotation = angle;
    }
}
