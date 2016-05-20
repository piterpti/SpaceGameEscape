﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FirstMiniGame : MonoBehaviour {

    [SerializeField]
    private Text interactionText;
    [SerializeField]
    private GameObject doorToOpen;
    [SerializeField]
    public GameControl state;

    private Animation doorAnimation;

    private bool displayText = true;


    private const string HIT_F_TO_INTERACT = "Wciśnij F, aby zhackować";
    private bool doorHacked = false;

	void Start () {
        doorAnimation = doorToOpen.GetComponent<Animation>();
	}
	
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (!doorHacked)
        {
            if (other.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST))
            {
                if (other.gameObject == ControllerSetup.CURRENT_CHARACTER)
                {
                    interactionText.text = HIT_F_TO_INTERACT;
                    displayText = true;
                }
                else
                {
                    if (displayText)
                    {
                        interactionText.text = null;
                        displayText = false;
                    }
                }
                if (Input.GetKeyDown(KeyCode.F) && other.gameObject == ControllerSetup.CURRENT_CHARACTER)
                {
                    state.openMiniGame();
                    GetComponent<AudioSource>().Play();
                }
            }
        }
        else
        {
            Destroy(GetComponent<FirstMiniGame>());
        }
    }

    void OnTriggerExit()
    {
        interactionText.text = null;
    }

    void ChangeDoorLights()
    {
        GameObject[] lights = GameObject.FindGameObjectsWithTag("DoorLight");
        foreach(GameObject light in lights)
        {
            light.GetComponent<Light>().color = Color.green;
        }
        GameObject[] materials = GameObject.FindGameObjectsWithTag("DoorLamp");
        foreach(GameObject material in materials)
        {
            material.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    public void ChangeHacked()
    {
        doorHacked = true;
        doorAnimation.Play();
        interactionText.text = null;
        ChangeDoorLights();
        doorToOpen.GetComponent<AudioSource>().Play();
    }
}
