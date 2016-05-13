using UnityEngine;
using System.Collections;

public class Hack : MonoBehaviour {

    [SerializeField]
    private GameObject secondDoorHack;

	void Update ()
    {
        // open 1st room doors
	    if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            OpenFirstDoor();
        }
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            OpenSecondDoor();
        }
	}

    void OpenFirstDoor()
    {
        GameObject panel = GameObject.Find("ComputerPanel1");
        ComputerHandlerMinigame minigame = panel.GetComponent<ComputerHandlerMinigame>();
        minigame.changeDoorHacked();
    }

    void OpenSecondDoor()
    {
        ComputerHandler handler = secondDoorHack.GetComponent<ComputerHandler>();
        handler.DoorOpen();
    }

}
