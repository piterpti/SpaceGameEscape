using UnityEngine;
using System.Collections;

public class BridgeOpen : MonoBehaviour {

    [SerializeField]
    private GameObject bridge;

    public bool isBridgeOpen = false;

    void Start()
    {
        
    }

	void OnTriggerEnter()
    {
        if (!isBridgeOpen)
        {
            GetComponent<Renderer>().material.color = Color.green;
            bridge.GetComponent<Animation>().Play();
            isBridgeOpen = true;
        }
    }
}
