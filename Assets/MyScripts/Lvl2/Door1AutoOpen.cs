using UnityEngine;
using System.Collections;

public class Door1AutoOpen : MonoBehaviour
{

    private Animation doorAnimation;
    private bool doorOpen = false;

    private const string ANIMATION_NAME = "door1OpenLvl2";

    void Start()
    {
        doorAnimation = GetComponent<Animation>();
    }



    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST) ||
            other.gameObject.name.Equals(Constants.CHARACTER_CATWOMAN) ||
            other.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            DoorOpen();
        }
    }

    void OnTriggerExit()
    {
        DoorClose();
    }


    public void DoorOpen()
    {
        if(enabled)
        if (!doorOpen)
        {
            doorAnimation[ANIMATION_NAME].speed = 1;
            doorAnimation.Play();
            doorOpen = true;
            GetComponent<AudioSource>().Play();
        }
    }

    public void DoorClose()
    {
        if(enabled)
        if (doorOpen)
        {
            doorAnimation[ANIMATION_NAME].time = doorAnimation[ANIMATION_NAME].length;
            doorAnimation[ANIMATION_NAME].speed = -1;
            doorAnimation.Play();
            doorOpen = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
