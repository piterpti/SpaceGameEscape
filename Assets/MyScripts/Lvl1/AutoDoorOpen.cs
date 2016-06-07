using UnityEngine;
using System.Collections;

public class AutoDoorOpen : MonoBehaviour {
        
    private Animation doorAnimation;
    private bool doorOpen = false;
    private bool firstTime = false;
    private bool temp = true;

    private AudioSource doorSound;

    void Start()
    {
        doorAnimation = GetComponent<Animation>();
        doorSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(firstTime && temp)
        {
            ChangeObjective();
            temp = false;           
        }
    }

	void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST) ||
            other.gameObject.name.Equals(Constants.CHARACTER_CATWOMAN) ||
            other.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            DoorOpen();
            firstTime = true;
        }      
    }

    void OnTriggerExit()
    {
        DoorClose();
    }
    

    public void DoorOpen()
    {
        if (!doorOpen)
        {
            doorAnimation["doorAutoOpen"].speed = 1;
            doorAnimation.Play();
            doorOpen = true;
            doorSound.Play();
        }
    }

    public void DoorClose()
    {
        if (doorOpen)
        {
            doorAnimation["doorAutoOpen"].time = doorAnimation["doorAutoOpen"].length;
            doorAnimation["doorAutoOpen"].speed = -1;
            doorAnimation.Play();
            doorOpen = false;
            doorSound.Play();
        }
    }

    private void ChangeObjective()
    {
        ObjectiveHandlerLvl1 handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandlerLvl1>();
        handler.nextTask(ObjectiveHandlerLvl1.MAYOMA_DESTROY_CHEST);
    }
}
