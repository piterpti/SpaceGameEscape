using UnityEngine;
using System.Collections;

public class Objective6 : MonoBehaviour {

    private bool firstTime = true;

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name.Equals(Constants.CHARACTER_CATWOMAN) ||
            other.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST) ||
            other.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        if (firstTime)
        {
            firstTime = false;
            ChangeObjective();
            Destroy(GetComponent<Objective6>());
        }
    }

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.TWO_FLOOR_STAND);
    }
}
