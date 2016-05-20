using UnityEngine;
using System.Collections;

public class RespawnOnButton : MonoBehaviour {

    [SerializeField]
    private Transform respawn1;
    [SerializeField]
    private Transform respawn2;
    [SerializeField]
    private Transform respawn3;
    [SerializeField]
    private DoorFromFloor checkpoint2;
    [SerializeField]
    private BridgeOpen checkpoint3;

    private Transform currentRespawn;

    private bool checkpoint2Unlocked = false;
    private bool checkpoint3Unlocked = false;
    void Start () {
        currentRespawn = respawn1;
	}
	
	
	void Update () {

	    if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            GameObject.Find(Constants.CHARACTER_MAYOMA).transform.position = currentRespawn.position + new Vector3(0f, 0f, 2f);
            GameObject.Find(Constants.CHARACTER_SCIENTIST).transform.position = currentRespawn.position + new Vector3(0f, 0f, 0f);
            GameObject.Find(Constants.CHARACTER_CATWOMAN).transform.position = currentRespawn.position + new Vector3(0f, 0f, -2f);
        }

        if (!checkpoint2Unlocked)
        {
            if (checkpoint2.isOpenPernamently)
            {
                currentRespawn = respawn2;
                checkpoint2Unlocked = true;
            }
        }
        else if(!checkpoint3Unlocked)
        {
            if(checkpoint3.isBridgeOpen)
            {
                currentRespawn = respawn3;
                checkpoint3Unlocked = true;
            }
        }
	}
}
