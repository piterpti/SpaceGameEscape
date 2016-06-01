using UnityEngine;
using System.Collections;

public class ObjectiveChange1 : MonoBehaviour {

    private bool isEntered = false;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerStay()
    {
        if(!isEntered)
        {
            isEntered = true;
            ChangeObjective();
        }
    }

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.DESTROY_CHESTS);
    }


}
