using UnityEngine;
using System.Collections;

public class AutoDoorOpen : MonoBehaviour {
        
    private Animation doorAnimation;
    private bool doorOpen = false;

    int interval = 5;
    float nextTime = 0;

    void Start()
    {
        doorAnimation = GetComponent<Animation>();
    }

    void Update()
    {
        if(Time.time >= nextTime)
        {
            if (doorOpen)
            {
                DoorClose();
            }
            nextTime += interval;
        }
    }

	void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST))
        {
            DoorOpen();
        }
        nextTime = Time.time + interval;
    }
    

    public void DoorOpen()
    {
        if (!doorOpen)
        {
            doorAnimation["door1Open"].speed = 1;
            doorAnimation.Play();
            doorOpen = true;
        }
    }

    public void DoorClose()
    {
        if (doorOpen)
        {
            doorAnimation["door1Open"].time = doorAnimation["door1Open"].length;
            doorAnimation["door1Open"].speed = -1;
            doorAnimation.Play();
            doorOpen = false;
        }
    }
}
