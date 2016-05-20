using UnityEngine;
using System.Collections;

public class LaserCollision : MonoBehaviour {

    [SerializeField]
    private GameObject MAYOMA;
    [SerializeField]
    private GameObject SCIENCIST;
    [SerializeField]
    private GameObject CATWOMAN;
    [SerializeField]
    private Transform respawnPoint;

    private AudioSource fail;

    void Start () {
        fail = GameObject.Find("Characters").GetComponent<AudioSource>();
	}
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == MAYOMA || 
            other.gameObject == SCIENCIST ||
            other.gameObject == CATWOMAN)
        {
            MAYOMA.transform.position = respawnPoint.position + (new Vector3(0f, 0f, 2f));
            SCIENCIST.transform.position = respawnPoint.position;
            CATWOMAN.transform.position = respawnPoint.position + (new Vector3(0f, 0f, -2f));
            fail.Play();
        }
    }
}
