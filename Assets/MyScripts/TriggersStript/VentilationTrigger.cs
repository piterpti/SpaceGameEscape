using UnityEngine;
using System.Collections;

public class VentilationTrigger : MonoBehaviour {

void OnTriggerEnter(Collider other)
    {
        ControllerSetup.DisableCharacterChange();
        ControllerSetup.DisableEnableFollowCharacter();
    }
    void OnTriggerExit(Collider other)
    {
        ControllerSetup.EnableCharacterChange();
        ControllerSetup.DisableEnableFollowCharacter();
    }
}
