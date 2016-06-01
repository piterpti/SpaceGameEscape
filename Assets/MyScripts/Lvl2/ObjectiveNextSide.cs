using UnityEngine;
using System.Collections;

public class ObjectiveNextSide : MonoBehaviour {

    private bool firstTime = true;

    void OnTriggerEnter()
    {
        if(firstTime)
        {
            firstTime = false;
            ChangeObjective();
            Destroy(GetComponent<ObjectiveNextSide>());
        }
    }

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.HELP_OTHERS);
    }

}
