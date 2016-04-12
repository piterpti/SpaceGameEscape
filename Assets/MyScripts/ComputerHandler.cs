﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComputerHandler : MonoBehaviour {

    [SerializeField]
    private string[] characterNames = {"Sciencist"};
    [SerializeField]
    private Text interactionText;
    [SerializeField]
    private GameObject doors;
    [SerializeField]
    private string textToDisplay = "F - interakcja";
    [SerializeField]

    public GameControl state;


    private Animation doorAnimation;
    private bool isDoorOpen = false;

	void Start ()
    {
        doorAnimation = doors.GetComponent<Animation>();
	}
	
	void Update ()
    {

	}

    void OnTriggerStay(Collider other)
    {
        if(Array.Exists(characterNames, element => element == other.gameObject.name))
        {
            if (other.gameObject == ControllerSetup.CURRENT_CHARACTER)
            {
                interactionText.text = textToDisplay;
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!isDoorOpen)
                    {
                        DoorOpen();
                    }
                    else
                    {
                        DoorClose();
                    }
                }
                
            }
            else
            {
                interactionText.text = "";
            }
        }
    }

    void OnTriggerExit()
    {
        interactionText.text = "";
    }

    // it must be public
    public void DoorOpen()
    {
        if (!isDoorOpen)
        {
            isDoorOpen = true;
            doorAnimation["door1Open"].speed = 1;
            doorAnimation.Play();
            textToDisplay = "F aby zamknąć";
        }
    }

    public void DoorClose()
    {
        if (isDoorOpen)
        {
            isDoorOpen = false;
            doorAnimation["door1Open"].time = doorAnimation["door1Open"].length;
            doorAnimation["door1Open"].speed = -1;
            doorAnimation.Play();
            textToDisplay = "F aby otworzyć";
        }
        
    }
}
