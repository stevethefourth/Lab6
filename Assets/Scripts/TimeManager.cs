using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private int lastTime = -1;
    private float timer;
    private float moveWait = 2.0f;


    public void Start()
    {
        resetTime();
        
    }

    public void Update()
    {
        timer += Time.deltaTime;
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

    private void resetTime()
    {
        timer = 0;
        lastTime = -1;
    }
    
}
