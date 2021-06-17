using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    public float speed = 400.0f;      
    public Camera cam; // ��������� ��� ������
    private Rigidbody2D _body; // ������ ��� ����

    Vector2 movement;// ������ ��������, �������� ������ � & y
    Vector2 mousePos;//�������� ������� ���� �� ����

    //

    
    // 
    void Update()
    {
        _body = GetComponent<Rigidbody2D>();// ������ ������ �������
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");//��������� ������� (������� � wasd)
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);// ������ - ������.��������� � ���������� (������� �����)

    }
    
    void FixedUpdate()
    {
        _body.MovePosition(_body.position + movement * speed * Time.fixedDeltaTime);//���� ��������� (���� ������, ����� ���� ���������� �� ���-�� ���)

        
        Vector2 lookDir = mousePos - _body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;   //� ����� ����� ����� ������
        _body.rotation = angle;
    }
}
