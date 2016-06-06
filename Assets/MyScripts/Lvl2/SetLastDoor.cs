using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetLastDoor : MonoBehaviour {

    [SerializeField]
    private Text interactionText;

    [SerializeField]
    private GameObject doorsToOpen;

    [SerializeField]
    private GameObject[] enemyLasres;

    private const string F_TO_OPEN = "F - interakcja";
    GameObject trigger;

    void Start () {
	    
	}
    void OnTriggerEnter()
    {
        trigger = GameObject.Find("StopCharactersBot");
    }

    void OnTriggerStay()
    {
        interactionText.text = F_TO_OPEN;
        GameObject floor = GameObject.Find("FloorToAnim");
        Animation animFloor = floor.GetComponent<Animation>();


        if (Input.GetKeyDown(KeyCode.F))
        {
           
            interactionText.text = null;

            
            animFloor.Play();

            doorsToOpen.GetComponent<DoorLightChange>().ChangeLights(Color.green);
            GetComponent<AudioSource>().Play();

            foreach(GameObject g in enemyLasres)
            {
                Destroy(g);
            }

            ChangeObjective();

            Destroy(GetComponent<SetLastDoor>());


        }




    }

    void OnTriggerExit()
    {
        interactionText.text = null;
    }

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.NEXT_SIDE);
    }
    
}
