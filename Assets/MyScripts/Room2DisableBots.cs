using UnityEngine;
using System.Collections;

public class Room2DisableBots : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        ControllerSetup.DisableFollorCharacter();
        ControllerSetup.DisableButtonQ();
       // CatwomanController.Reset();
        MayomaController.Reset();
        SciencistController.Reset();

    }
}