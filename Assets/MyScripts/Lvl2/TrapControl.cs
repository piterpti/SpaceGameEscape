using UnityEngine;
using System.Collections;

public class TrapControl : MonoBehaviour {

    private GameObject respawnPoint;

	void Start () {
        respawnPoint = GameObject.Find("RespawnPoint");
	}
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        other.transform.position = respawnPoint.transform.position;
    }
}
