using UnityEngine;
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
    private bool laserOff = false;

    private const string HIT_F_TO_INTERACT = "Press F to hack";
    private bool doorHacked = false;
    private ObjectiveHandler handler;


    void Start () {
        doorAnimation = doorToOpen.GetComponent<Animation>();
        handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
    }
	
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (laserOff)
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
                        handler.setTempText("Drag the white circle to the red square\n with the mouse");

                    }
                }
            }
            else
            {
                Destroy(GetComponent<FirstMiniGame>());
            }
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
        ChangeObjective();
    }

    public void LasersOff()
    {
        laserOff = true;
    }
    private void ChangeObjective()
    {
        handler.nextTask(ObjectiveHandler.TASKS_GO_TO_THE_ROOM);        
    }
}
