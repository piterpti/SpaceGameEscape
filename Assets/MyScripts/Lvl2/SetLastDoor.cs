﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetLastDoor : MonoBehaviour {

    [SerializeField]
    private Text interactionText;

    [SerializeField]
    private GameObject doorsToOpen;

    [SerializeField]
    private GameObject[] enemyLasres;

    private const string F_TO_OPEN = "F - interakcja";

	void Start () {
	    
	}
	
	void OnTriggerStay()
    {
        interactionText.text = F_TO_OPEN;

        if (Input.GetKeyDown(KeyCode.F))
        {            
            doorsToOpen.GetComponent<DoorFromFloor>().isOpenPernamently = true;
            interactionText.text = null;

            GameObject floor = GameObject.Find("FloorToAnim");
            Animation animFloor = floor.GetComponent<Animation>();
            animFloor.Play();

            doorsToOpen.GetComponent<DoorLightChange>().ChangeLights(Color.green);

            foreach(GameObject g in enemyLasres)
            {
                Destroy(g);
            }

            Destroy(GetComponent<SetLastDoor>());
            
        }
    }

    void OnTriggerExit()
    {
        interactionText.text = null;
    }
}
