using UnityEngine;
using System.Collections;

public class FloorTrigger : MonoBehaviour {

    private bool isChanged = false;

    void OnTriggerEnter()
    {
        if (!isChanged)
        {
            Lvl1Hints hint = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<Lvl1Hints>();
            hint.setText("Open the door for others!");
        }
    }
}
