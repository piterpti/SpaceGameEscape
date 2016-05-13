using UnityEngine;
using System.Collections;

public class FloorStand : MonoBehaviour {

    public bool isOn;
    
	void Start () {
        isOn = false;
	}
	
	void Update () {
	    
	}

    void OnTriggerStay(Collider other)
    {
        string otherName = other.gameObject.name;
        if(otherName == Constants.CHARACTER_CATWOMAN ||
            otherName == Constants.CHARACTER_MAYOMA || 
            otherName == Constants.CHARACTER_SCIENTIST)
        {
            isOn = true;
            GetComponent<Renderer>().material.color = Color.green;
        } 
    }
    
    void OnTriggerExit()
    {
        isOn = false;
        GetComponent<Renderer>().material.color = Color.red;
    }
}
