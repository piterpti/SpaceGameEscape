using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class metaTrigger : MonoBehaviour {

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        GameObject control = GameObject.Find("GameController");
        GameControl gameControl = control.GetComponent<GameControl>();
        gameControl.endMiniGame(true);
    }
}
