using UnityEngine;
using System.Collections;

public class LastRoomObjective : MonoBehaviour {

    private bool mayomaEnter = false;
    private bool sciencistEnter = false;
    private bool firstTime = true;
	
	void Update () {
	    if(firstTime && mayomaEnter && sciencistEnter)
        {
            Lvl1Hints hint = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<Lvl1Hints>();
            hint.setStatus(true, "Congratulations! Come over doors all characters");
            firstTime = false;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            mayomaEnter = true;
        }
        if(other.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST))
        {
            sciencistEnter = true;
        }
    }
}
