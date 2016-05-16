using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComputerHandlerMinigame : MonoBehaviour {

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
     
   
    private bool doorHacked = false;
    private bool isDoorOpen = false;
    private Animation doorAnimation;

	void Start ()
    {
        doorAnimation = doors.GetComponent<Animation>();
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
                    if (!doorHacked)
                    {
                        state.openMiniGame();
                        GetComponent<AudioSource>().Play();
                    }
                    else
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

    public void changeDoorHacked()
    {
        doorHacked = true;
        DoorOpen();
        textToDisplay = "F aby zamknąć";
        characterNames = new string[]{ Constants.CHARACTER_SCIENTIST,
                                        Constants.CHARACTER_MAYOMA,
                                        Constants.CHARACTER_CATWOMAN};

        GameObject doorLight = GameObject.Find("DoorLight1");
        doorLight.GetComponent<Light>().color = Color.green;
        GameObject.Find("DoorLamp1").GetComponent<Renderer>().material.color = Color.green;
        GameObject.Find("DoorLamp2").GetComponent<Renderer>().material.color = Color.green;
        GameObject.Find("DoorLamp3").GetComponent<Renderer>().material.color = Color.green;
        GameObject.Find("DoorLamp4").GetComponent<Renderer>().material.color = Color.green;
        GameObject.Find("DoorLamp5").GetComponent<Renderer>().material.color = Color.green;
        GameObject.Find("DoorLamp6").GetComponent<Renderer>().material.color = Color.green;
    }
}
