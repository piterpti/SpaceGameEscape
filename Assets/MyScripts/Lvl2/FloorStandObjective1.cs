using UnityEngine;
using System.Collections;

public class FloorStandObjective1 : MonoBehaviour
{

    [SerializeField]
    private GameObject doors;

    public bool isOn;
    private bool firstTime = true;


    void Start()
    {
        isOn = false;
    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        string otherName = other.gameObject.name;
        if (otherName == Constants.CHARACTER_CATWOMAN ||
            otherName == Constants.CHARACTER_MAYOMA ||
            otherName == Constants.CHARACTER_SCIENTIST)
        {
            isOn = true;
            GameObject floor = GameObject.Find("FloorToAnim2");
            Animation animFloor = floor.GetComponent<Animation>();
            GetComponent<Renderer>().material.color = Color.green;
            animFloor.Play();
            if (firstTime)
            {
                firstTime = false;
                ChangeObjective();
            }
        }
    }

    void OnTriggerExit()
    {
        isOn = false;
        GetComponent<Renderer>().material.color = Color.red;
    }

    private void ChangeObjective()
    {
        doors.GetComponent<Door1AutoOpen>().enabled = true;
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.TASKS_GO_TO_THE_ROOM);
    }
}
