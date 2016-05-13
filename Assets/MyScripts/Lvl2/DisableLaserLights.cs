using UnityEngine;
using System.Collections;

public class DisableLaserLights : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(GetComponent<laserScript>());
	    foreach(Transform child in transform)
        {
            if(child.gameObject.name != "endTurret" && 
                child.gameObject.name != "startTurret")
            {
                Destroy(child.gameObject);
            }
        }
        Destroy(GetComponent <DisableLaserLights>());
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
