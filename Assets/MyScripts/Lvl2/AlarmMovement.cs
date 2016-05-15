using UnityEngine;
using System.Collections;

public class AlarmMovement : MonoBehaviour {

    [SerializeField]
    private Transform center;
    private float speed = 300f;

	void Start () {
	
	}
	
	void Update () {
        transform.RotateAround(center.position, Vector3.up, speed * Time.deltaTime);
    }
}
