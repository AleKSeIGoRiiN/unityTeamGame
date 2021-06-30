using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMoving : MonoBehaviour
{
    public canvasStop canvasStop;
    public const float maxSpeed = 0.07f;
    
    Vector3 moving = Vector3.zero;
    Vector3 endMoving = Vector3.zero;
    int count = 0;
    float speedX = 0f;
    float speedY = 0f;
    float speedingX = 0.001f;
    float speedingY = 0.001f;
    float camChanging = 0.007f;
    float firstCamSize = 8.635898f;
    float changeCamSize = 0f;
    

    bool firstStage = true;
    bool secondStage = false;
    bool thrithStage = false;
    bool endingStage = false;
    bool waitingStage = false;
    bool flagKeySpace = true;

    
    void Start()
    {
        moving.x = -223.47f;
        moving.y = 43.96f;
        moving.z = -10f;
        endMoving.z = -10f;
    }

    
    void Update()
    {

        if(firstStage && moving.y < 82f)
        {
            
            moving.y += speedY;
            if(speedY < maxSpeed)
            {
                speedY += speedingY;
            }

        }
        else if(firstStage)
        {
            
            firstStage = false;
            secondStage = true;
            speedingY = -speedingY;
        }
        
        if(secondStage && moving.x < -130f)
        {
            
            moving.x += speedX;
            moving.y += speedY;
            if(speedX < maxSpeed) speedX += speedingX;
            if(speedY > 0f) speedY += speedingY;
        }
        else if (secondStage)
        {
            
            secondStage = false;
            thrithStage = true;
            speedingX = -speedingX;
        }

        if(thrithStage && moving.y > 46f)
        {
            
            moving.x += speedX;
            moving.y += speedY;
            if(speedX > 0f) speedX += speedingX;
            if(speedY > -maxSpeed) speedY += speedingY;

        }
        else if(thrithStage)
        {
            
            thrithStage = false;
            endingStage = true;
            speedingY = -speedingY;

        }
        if(endingStage && moving.x > -170f && moving.y < 70f )
        {
            
            moving.x += speedX;
            moving.y += speedY;
            if(speedX > -maxSpeed) speedX += speedingX;
            if(speedY < maxSpeed) speedY += speedingY;
        }
        else if (endingStage)
        {
            
            endingStage = false;
            waitingStage = true;
            speedingX = -speedingX;
            speedingY = -speedingY;
        }
        if(waitingStage && Camera.main.orthographicSize < 29f)
        {
            Camera.main.orthographicSize += camChanging;


        }
        //
        if(Input.GetKeyDown(KeyCode.Space) && flagKeySpace)
        {
            flagKeySpace = false;
            endMoving.x = (-223.3f - moving.x) / 60f;
            endMoving.y = (44.2f - moving.y) / 60f;
            changeCamSize = (Camera.main.orthographicSize - firstCamSize) / 60f;
            
        }
        else if(flagKeySpace != true && count < 59)
        {
            count ++;
            Camera.main.orthographicSize -= changeCamSize;
            moving.x += endMoving.x;
            moving.y += endMoving.y;
        }
        else if(flagKeySpace != true && count >= 59)
        {
            moving.x = -223.3f;
            moving.y = 44.2f;
            transform.position = moving;
            canvasStop.SetActive(true);
            GetComponent<dg_simpleCamFollow>().enabled = true;
            GetComponent<camMoving>().enabled = false;
        }
        else if(flagKeySpace == true || count < 59) canvasStop.SetActive(false);



        
    }
    void FixedUpdate()
    {
        transform.position = moving;
    }
}
