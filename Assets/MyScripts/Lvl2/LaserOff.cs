﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LaserOff : MonoBehaviour {
    
    [SerializeField]
    private Text interactionText;
    [SerializeField]
    private FirstMiniGame callWhenLaserOffs;
    
    
    private bool isLaserDestroyed;
    private const string LASER_OFF_TEXT = "Press F to disable lasers";
    private bool displayText = true;

	void Start () {
        
	}
	
	void Update () {
	    
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == ControllerSetup.CURRENT_CHARACTER)
        {
            interactionText.text = LASER_OFF_TEXT;
        }
        else
        {
            if(displayText)
            {
                interactionText.text = null;
                displayText = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && other.gameObject == ControllerSetup.CURRENT_CHARACTER)
        {
            GameObject[] lasers = GameObject.FindGameObjectsWithTag("Laser");
            foreach(GameObject laser in lasers)
            {
                Animator anim = laser.GetComponent<Animator>();
                if(anim != null)
                {
                    anim.enabled = false;
                }
                laser.GetComponent<DisableLaserLights>().enabled = true;
                laser.GetComponent<AudioSource>().enabled = false;
                Destroy(laser.GetComponent<LaserCollision>());
                
            }

            GameObject laserHorizontal = GameObject.Find("LaserVertical");
            laserHorizontal.GetComponent<Animator>().enabled = false;
            GetComponent<AudioSource>().Play();
            ChangeObjective();


            Destroy(GetComponent<LaserOff>());
            interactionText.text = null;
        }
    }

    void OnTriggerExit()
    {
        interactionText.text = null;
    }

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.TASKS_HACK_COMPUTER);
        callWhenLaserOffs.LasersOff();
    }
}
