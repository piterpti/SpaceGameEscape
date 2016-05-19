using UnityEngine;
using System.Collections;

public class EndFloor : MonoBehaviour {

    [SerializeField]
    private GameObject floorToAnim;
    [SerializeField]
    private GameObject bridgeControlFloor;

    private Animation floorAnimation;
    private BridgeOpen bridgeOpenScript;

    private bool floorUp = false;
    private const string ANIMATION_NAME = "AnimatedFloor";

    private bool isEnded = false;

	void Start () {
        floorAnimation = floorToAnim.GetComponent<Animation>();
        bridgeOpenScript = bridgeControlFloor.GetComponent<BridgeOpen>();
	}
	
	void Update () {
        if (bridgeOpenScript.isBridgeOpen)
            isEnded = true;
	}

    void OnTriggerStay()
    {
        if (!isEnded)
        {
            FloorUp();
        }
        else
        {
            FloorDown();
            Destroy(GetComponent<EndFloor>());
        }
    }

    void OnTriggerExit()
    {
        FloorDown();
    }

    private void ColorChange(Color c)
    {
        GetComponent<Renderer>().material.color = c;
    }

    public void FloorUp()
    {
        if(!floorUp)
        {
            floorAnimation[ANIMATION_NAME].speed = 1;
            floorAnimation.Play();
            ColorChange(Color.green);
            floorUp = !floorUp;
        }

    }

    public void FloorDown()
    {
        if(floorUp)
        {
            floorAnimation[ANIMATION_NAME].time = floorAnimation[ANIMATION_NAME].length - floorAnimation[ANIMATION_NAME].time;
            floorAnimation[ANIMATION_NAME].speed = -1;
            floorAnimation.Play();
            ColorChange(Color.red);
            floorUp = !floorUp;
        }
    }


   /* public void DoorOpen()
    {
        if (!doorOpen)
        {
            doorAnimation[ANIMATION_NAME].speed = 1;
            doorAnimation.Play();
            doorOpen = true;
        }
    }

    public void DoorClose()
    {
        if (doorOpen)
        {
            doorAnimation[ANIMATION_NAME].time = doorAnimation[ANIMATION_NAME].length;
            doorAnimation[ANIMATION_NAME].speed = -1;
            doorAnimation.Play();
            doorOpen = false;
        }
    }*/
}
