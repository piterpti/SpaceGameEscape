﻿using UnityEngine;
using System.Collections;

public class DoorFromFloor : MonoBehaviour {

    public bool isOpenPernamently;

    private Animation doorAnimation;
    private bool doorOpen;
    private const string ANIMATION_NAME = "door2Open";

    void Start () {
        doorAnimation= GetComponent<Animation>();
        doorOpen = false;
        isOpenPernamently = false;
	}
	
	void Update () {
        if (isOpenPernamently)
        {
            DoorOpen();
            Destroy(GetComponent<DoorFromFloor>());
        }
        else
        {
            int counter = 0;
            GameObject[] floors = GameObject.FindGameObjectsWithTag("InteractiveFloor");
            foreach (GameObject g in floors)
            {
                if (g.GetComponent<FloorStand>().isOn)
                {
                    counter++;
                }
            }

            if (counter == 2)
            {
                DoorOpen();
            }
            else
            {
                DoorClose();
            }

            if (Input.GetKeyDown(KeyCode.T))
            {
                DoorOpen();
            }
        }
	}

    public void DoorOpen()
    {
        if (!doorOpen)
        {

            doorAnimation[ANIMATION_NAME].speed = 1;
            doorAnimation.Play();
            doorOpen = true;
        }
    }

    public void DoorClose()
    {
        if (doorOpen)
        {
            doorAnimation[ANIMATION_NAME].time = doorAnimation[ANIMATION_NAME].length;
            doorAnimation[ANIMATION_NAME].speed = -1;
            doorAnimation.Play();
            doorOpen = false;
        }
    }
}
