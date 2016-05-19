using UnityEngine;
using System.Collections;

public class DoorLightChange : MonoBehaviour {

    [SerializeField]
    private GameObject[] lamps;
    [SerializeField]
    private Light[] lights;

	public void ChangeLights(Color c)
    {
        foreach(GameObject lamp in lamps)
        {
            lamp.GetComponent<Renderer>().material.color = c;
        }
        foreach(Light light in lights)
        {
            light.color = c;
        }
    }
}
