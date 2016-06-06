using UnityEngine;
using System.Collections;

public class AnimFloorTriggerNavMesh : MonoBehaviour {
    GameObject trigger;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "AnimatedFloorTrigger") {

            trigger = GameObject.Find("StopCharactersBot");
            trigger.SetActive(false);
            ControllerSetup.EnableFollorCharacter();
            ControllerSetup.EnableButtonQ();
    }
}
