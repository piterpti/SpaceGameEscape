using UnityEngine;
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
        }
        else
        {
            int counter = 0;
            GameObject[] floors = GameObject.FindGameObjectsWithTag("InteractiveFloor");
            foreach (GameObject g in floors)
            {
                if (g.GetComponent<FloorStand>() != null && g.GetComponent<FloorStand>().isOn)
                {
                    counter++;
                }
                if(g.GetComponent<FloorStandObjective1>() != null && g.GetComponent<FloorStandObjective1>().isOn)
                {
                    counter++;
                }
            }

            if (counter == 2)
            {
                DoorOpen();
                isOpenPernamently = true;
                ChangeObjective();
                Destroy(GetComponent<DoorFromFloor>());
            }            
        }
	}

    public void DoorOpen()
    {
        if (!doorOpen)
        {
            GetComponent<DoorLightChange>().ChangeLights(Color.green);
            doorAnimation[ANIMATION_NAME].speed = 1;
            doorAnimation.Play();
            doorOpen = true;
            GetComponent<AudioSource>().Play();
        }
    }

    public void DoorClose()
    {
        if (doorOpen)
        {
            GetComponent<DoorLightChange>().ChangeLights(Color.red);
            doorAnimation[ANIMATION_NAME].time = doorAnimation[ANIMATION_NAME].length;
            doorAnimation[ANIMATION_NAME].speed = -1;
            doorAnimation.Play();
            doorOpen = false;
            GetComponent<AudioSource>().Play();
        }
    }

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.SECOND_DOORS_OPEN);
    }
}
