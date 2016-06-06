using UnityEngine;
using System.Collections;

public class NavMeshDisableRoom2 : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        //ControllerSetup.DisableButtonQ();
        ControllerSetup.DisableFollorCharacter();
        
        
    }
    void OnTriggerExit()
    {
       
    }
}
