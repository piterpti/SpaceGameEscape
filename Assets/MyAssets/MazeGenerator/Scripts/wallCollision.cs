using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wallCollision : MonoBehaviour {
    public Transform myCoolPrefab;

    private int counter;
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Vector3 temp = new Vector3(MazeGenerator.player_x, MazeGenerator.player_y, 0);
        Instantiate(myCoolPrefab, temp, transform.rotation);
    }

    void Update()
    {
        counter = 0;
        foreach(GameObject player in GameObject.FindGameObjectsWithTag("MinigamePlayer"))
        {
            if(++counter > 1)
            {
                Destroy(player);
            }
        }
    }
}
