using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float cameraSpeed = 5f;
    public float offset = 0.1f;

    public bool isAtTopWall = true;
    public bool isAtBottomWall = false;

    public float topWallPosition = -4.42f;
    public float bottomWallPosition = -11.98f;

    public bool isAtRightWall = false;
    public bool isAtLeftWall = false;

    public float rightWallPosition = 38.28f;
    public float leftWallPosition = -16.27f;

    void CameraMoveVertical()
    {
        

        if (transform.position.y >= topWallPosition)
            isAtTopWall = true;
        else 
            isAtTopWall = false;
        
        if(transform.position.y <= bottomWallPosition)
            isAtBottomWall = true;
        else
            isAtBottomWall = false;

        if (Input.GetKey(KeyCode.W) && !isAtTopWall)
        {
            transform.position += transform.up * cameraSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && !isAtBottomWall)
        {
            transform.position -= transform.up * cameraSpeed * Time.deltaTime;
        }


    }

    void CameraMoveHorizontal()
    {

      

        if (transform.position.x >= rightWallPosition)
            isAtRightWall = true;
        else
            isAtRightWall = false;

        if(transform.position.x <= leftWallPosition)
            isAtLeftWall = true;
        else
            isAtLeftWall = false;

        if (Input.GetKey(KeyCode.D) && !isAtRightWall)
        { 
            transform.position += transform.right * cameraSpeed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A ) && !isAtLeftWall)
        {
            transform.position -= transform.right * cameraSpeed * Time.deltaTime;
        }
           
    }


    void FixedUpdate()
    {
   
        CameraMoveHorizontal();
        CameraMoveVertical();
       
    }

}