using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComputerHandler : MonoBehaviour {

    [SerializeField]
    private string CharacterName = "Sciencist";
    [SerializeField]
    private Text interactionText;
    [SerializeField]
    private GameObject doors;

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
        if(other.gameObject.name.Equals(CharacterName))
        {
            interactionText.text = "Wciśnij F aby zhakować";
            if(Input.GetKeyDown(KeyCode.F))
            {  
                DoorOpen();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                DoorClose();                
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
        }
        
    }
}
