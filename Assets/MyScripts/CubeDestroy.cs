using UnityEngine;
using System.Collections;

public class CubeDestroy : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            GetComponent<Animator>().enabled = true;
            Destroy(gameObject, 2f);
        }
    }
}
