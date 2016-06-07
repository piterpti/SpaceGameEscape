using UnityEngine;
using System.Collections;

public class BrigdeObstacle : MonoBehaviour {
    private GameObject NavObstacle;
    private GameObject NavObstacle2;

    void DeleteObstacle() {
        NavObstacle = GameObject.Find("NavObstacle");
        NavObstacle.SetActive(false);
        NavObstacle2 = GameObject.Find("NavObstacle2");
        NavObstacle2.SetActive(false);
    }
}
