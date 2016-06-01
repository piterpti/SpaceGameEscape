using UnityEngine;
using System.Collections;

public class ObjectiveChestDestroy : MonoBehaviour {

    private bool firstTime = true;

	void Start () {
	
	}
	
	void Update () {
        if(firstTime && GameObject.FindGameObjectsWithTag("ChestToDestroy").Length < 1)
        {
            firstTime = false;
            ChangeObjective();
            Destroy(GetComponent<ObjectiveChestDestroy>());
        }
	}

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.CHESTS_DESTROYED);
    }
}
