using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FirstMiniGame : MonoBehaviour {

    [SerializeField]
    private Text interactionText;
    [SerializeField]
    private GameObject doorToOpen;

    private Animation doorAnimation;


    private const string HIT_F_TO_INTERACT = "Wciśnij F, aby zhackować";

	void Start () {
        doorAnimation = doorToOpen.GetComponent<Animation>();
	}
	
	void Update () {
	
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST))
        {
            interactionText.text = HIT_F_TO_INTERACT;
            if(Input.GetKeyDown(KeyCode.F))
            {
                doorAnimation.Play();
                interactionText.text = null;
                Destroy(GetComponent<FirstMiniGame>());
            }
        }
    }

    void OnTriggerExit()
    {
        interactionText.text = null;
    }
}
