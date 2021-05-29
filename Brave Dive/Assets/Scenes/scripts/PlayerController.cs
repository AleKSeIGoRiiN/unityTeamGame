using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 400.0f;
    private Rigidbody2D _body;

    //
    void Start()
    {
        Application.targetFrameRate = 60;
        _body = GetComponent<Rigidbody2D>();

    }

    // 
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float deltaY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, deltaY);
        _body.velocity = movement;

    }
}
