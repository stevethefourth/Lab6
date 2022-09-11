using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int lastTime = -1;
    private float timer;
    private float moveWait = 2.0f;
    private float nextMove = 2.0f;
    [SerializeField] private Transform[] transformArray;
    Camera mainCamera;
    private float redX;
    private float redY;
    private float blueX;
    private float blueY;




    public void Start()
    {
        resetTime();
        mainCamera = Camera.main;
        mainCamera.orthographic = true;
        mainCamera.orthographicSize = 2.5f;
    }

    public void Update()
    {
        timer += Time.deltaTime;
        if((int)timer == nextMove)
        {
            nextMove = (int)timer + moveWait;
            MoveObject();
        }
        
        if ((int)timer > lastTime)
        {
            Debug.Log((int)timer);
            lastTime = (int)timer;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.timeScale == 1.0f)
            {
                Time.timeScale = 0.0f;
            }

            else if(Time.timeScale == 0.0f)
            {
                Time.timeScale = 1.0f;
            }

            Debug.Log("Spacebar pressed");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            resetTime();
        }

    }
    private void MoveObject() 
    {
        
        redX = transformArray[0].position.x;
        redY = transformArray[0].position.y;
        blueX = transformArray[1].position.x;
        blueY = transformArray[1].position.y;

        switch (redX+redY)
        {
            case 3:
                transformArray[0].SetPositionAndRotation(new Vector3(2.0f, -1.0f, -0.0f), Quaternion.identity);
                break;
            case 1:
                transformArray[0].SetPositionAndRotation(new Vector3(-2.0f, -1.0f, -0.0f), Quaternion.identity);
                break;
            case -3:
                transformArray[0].SetPositionAndRotation(new Vector3(-2.0f, 1.0f, -0.0f), Quaternion.identity);
                break;
            case -1:
                transformArray[0].SetPositionAndRotation(new Vector3(2.0f, 1.0f, -0.0f), Quaternion.identity);
                break;
        }

        switch (blueX + blueY)
        {
            case 3:
                transformArray[1].SetPositionAndRotation(new Vector3(2.0f, -1.0f, -0.0f), Quaternion.identity);
                break;
            case 1:
                transformArray[1].SetPositionAndRotation(new Vector3(-2.0f, -1.0f, -0.0f), Quaternion.identity);
                break;
            case -3:
                transformArray[1].SetPositionAndRotation(new Vector3(-2.0f, 1.0f, -0.0f), Quaternion.identity);
                break;
            case -1:
                transformArray[1].SetPositionAndRotation(new Vector3(2.0f, 1.0f, -0.0f), Quaternion.identity);
                break;
        }


    }



    private void resetTime()
    {
        timer = 0;
        lastTime = -1;
    }
    
}
