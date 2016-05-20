using UnityEngine;
using System.Collections;

public class NavMeshEnableRoom2 : MonoBehaviour {

    void OnTriggerEnter()
    {
        ControllerSetup.EnableButtonQ();
        //ControllerSetup.EnableFollorCharacter();
    }
    void OnTriggerExit()
    {

    }
}
