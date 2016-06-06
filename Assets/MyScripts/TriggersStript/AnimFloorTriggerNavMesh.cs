using UnityEngine;
using System.Collections;

public class AnimFloorTriggerNavMesh : MonoBehaviour {
    GameObject trigger;

        
    public void EnableBots()
    {
        trigger = GameObject.Find("StopCharactersBot");
        trigger.SetActive(false);
        ControllerSetup.EnableButtonQ();
        ControllerSetup.EnableFollorCharacter();
    }
}
