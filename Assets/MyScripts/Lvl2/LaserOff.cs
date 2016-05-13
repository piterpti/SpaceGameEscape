using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class LaserOff : MonoBehaviour {
    
    [SerializeField]
    private Text interactionText;

    private bool isLaserDestroyed;
    private const string LASER_OFF_TEXT = "F, aby wyłączyć lasery";

	void Start () {
        
	}
	
	void Update () {
	    
	}

    void OnTriggerStay()
    {
        interactionText.text = LASER_OFF_TEXT;
        if (Input.GetKeyDown(KeyCode.F))
        {
            GameObject[] lasers = GameObject.FindGameObjectsWithTag("Laser");
            foreach(GameObject laser in lasers)
            {
                Animator anim = laser.GetComponent<Animator>();
                if(anim != null)
                {
                    anim.enabled = false;
                }
                laser.GetComponent<DisableLaserLights>().enabled = true;
                Destroy(laser.GetComponent<LaserCollision>());
                
            }

            GameObject laserHorizontal = GameObject.Find("LaserVertical");
            laserHorizontal.GetComponent<Animator>().enabled = false;

            Destroy(GetComponent<LaserOff>());
            interactionText.text = null;
        }
    }

    void OnTriggerExit()
    {
        interactionText.text = null;
    }
}
