using UnityEngine;
using System.Collections;

public class FloorTrigger : MonoBehaviour {

    private bool isChanged = false;

    void OnTriggerEnter()
    {
        if (!isChanged)
        {
            ChangeObjective();
            isChanged = true;
        }
    }

    private void ChangeObjective()
    {
        ObjectiveHandlerLvl1 handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandlerLvl1>();
        handler.nextTask(ObjectiveHandlerLvl1.OPEN_DOORS);
    }
}
