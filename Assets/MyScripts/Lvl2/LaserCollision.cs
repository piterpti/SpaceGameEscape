using UnityEngine;
using System.Collections;

public class LaserCollision : MonoBehaviour {

    [SerializeField]
    private GameObject MAYOMA;
    [SerializeField]
    private GameObject SCIENCIST;
    [SerializeField]
    private GameObject CATWOMAN;

    void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == MAYOMA || 
            other.gameObject == SCIENCIST ||
            other.gameObject == CATWOMAN)
        {
            MAYOMA.transform.position = new Vector3(-8f, 0.85f, 3.4f);
            SCIENCIST.transform.position = new Vector3(-8.26f, 0.85f, 4.77f);
            CATWOMAN.transform.position = new Vector3(-8.17f, 0.85f, 6.13f);
        }
    }
}
