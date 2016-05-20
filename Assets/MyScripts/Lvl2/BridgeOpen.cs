using UnityEngine;
using System.Collections;

public class BridgeOpen : MonoBehaviour {

    [SerializeField]
    private GameObject bridge;

    public bool isBridgeOpen = false;
    private GameObject trigger;
    void Start()
    {
        
    }

	void OnTriggerEnter()
    {
        ControllerSetup.EnableButtonQ();
        trigger = GameObject.Find("NavMeshDisableTrigger");
        trigger.active = false;
        if (!isBridgeOpen)
        {
            GetComponent<Renderer>().material.color = Color.green;
            bridge.GetComponent<Animation>().Play();
            isBridgeOpen = true;
        }
    }
}
