using UnityEngine;
using System.Collections;

public class CubeDestroy : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Animator>().enabled = true;
            GetComponent<AudioSource>().Play();
            Destroy(gameObject, 2f);
        }
    }
}
