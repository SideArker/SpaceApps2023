using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBackground : MonoBehaviour
{

    public CameraMovement cameraMovement;

    public float backgroundMovingSpeed = 2f;
    void MoveBackground()
    {
        float inputX = Input.GetAxis("Horizontal") * backgroundMovingSpeed * Time.deltaTime;

        transform.Translate(inputX, 0 ,0);

    }
    void Update()
    {
       
        if(Input.GetKey(KeyCode.A) && cameraMovement.isAtLeftWall == false)
            MoveBackground();
        else if(Input.GetKey(KeyCode.D) && cameraMovement.isAtRightWall == false)
            MoveBackground();
        
        
    }

}
