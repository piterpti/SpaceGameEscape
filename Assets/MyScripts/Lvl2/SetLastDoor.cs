using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetLastDoor : MonoBehaviour {

    [SerializeField]
    private Text interactionText;

    [SerializeField]
    private GameObject doorsToOpen;

    private const string F_TO_OPEN = "F - interakcja";

	void Start () {
	    
	}
	
	void Update () {
	
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

            Destroy(GetComponent<SetLastDoor>());
        }
    }

    void OnTriggerExit()
    {
        interactionText.text = null;
    }
}
