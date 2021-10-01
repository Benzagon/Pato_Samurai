﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour {

    private PlatformEffector2D effector;
    public float waitTime;

	void Start () {
        effector = GetComponent<PlatformEffector2D>();
	}
	
	
	void Update ()
    {
        if(Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.5f;
        }

	    if(Input.GetKey(KeyCode.S))
        {
            if(waitTime <= 0)
            {
                effector.rotationalOffset = 180f;
                waitTime = 0.5f;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.W))
            effector.rotationalOffset = 0f;
	}
   
}
