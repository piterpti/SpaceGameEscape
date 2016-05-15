using UnityEngine;
using System.Collections;

public class DoorLightChange : MonoBehaviour {

    [SerializeField]
    private GameObject[] lamps;
    [SerializeField]
    private Light[] lights;

	public void ChangeLights()
    {
        foreach(GameObject lamp in lamps)
        {
            lamp.GetComponent<Renderer>().material.color = Color.green;
        }
        foreach(Light light in lights)
        {
            light.color = Color.green;
        }
    }
}
