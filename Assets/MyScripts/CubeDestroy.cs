using UnityEngine;
using System.Collections;

public class CubeDestroy : MonoBehaviour {

    private bool isDestroyed = false;

    void OnTriggerStay(Collider other)
    {
        if(!isDestroyed && Input.GetKeyDown(KeyCode.Space) && other.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            isDestroyed = true;
            StartCoroutine(DestroyChest());
        }
    }

    IEnumerator DestroyChest()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Animator>().enabled = true;
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 2f);
    }
}
