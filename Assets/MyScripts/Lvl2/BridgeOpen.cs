using UnityEngine;
using System.Collections;

public class BridgeOpen : MonoBehaviour {

    [SerializeField]
    private GameObject bridge;

    public bool isBridgeOpen = false;
    private GameObject NavObstacle;
    void Start()
    {
        
    }

	void OnTriggerEnter()
    {
        ControllerSetup.EnableButtonQ();
        NavObstacle = GameObject.Find("NavObstacle");
        NavObstacle.SetActive(false);
        if (!isBridgeOpen)
        {
            GetComponent<Renderer>().material.color = Color.green;
            bridge.GetComponent<Animation>().Play();
            ChangeObjective();
            isBridgeOpen = true;
        }
    }

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.END_GAME);
    }
}
