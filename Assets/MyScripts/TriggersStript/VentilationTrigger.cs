using UnityEngine;
using System.Collections;

public class VentilationTrigger : MonoBehaviour {

void OnTriggerEnter(Collider other)
    {
        ControllerSetup.DisableCharacterChange();
    }
    void OnTriggerExit(Collider other)
    {
        ControllerSetup.EnableCharacterChange();
    }
}
