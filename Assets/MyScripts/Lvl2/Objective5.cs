using UnityEngine;
using System.Collections;

public class Objective5 : MonoBehaviour {

    private bool firstTime = true;

    void OnTriggerEnter()
    {
        if(firstTime)
        {
            ChangeObjective();
            firstTime = false;
            Destroy(GetComponent<Objective5>());
        }
    }

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.THROUH_CORRIDOR);
    }
}
