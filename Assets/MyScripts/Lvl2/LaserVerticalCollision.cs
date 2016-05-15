using UnityEngine;
using System.Collections;

public class LaserVerticalCollision : MonoBehaviour {

    [SerializeField]
    private Transform respawnPoint;

	void OnTriggerEnter(Collider other)
    {
        other.transform.position = respawnPoint.position;
    }
}
