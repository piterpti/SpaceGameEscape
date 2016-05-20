﻿using UnityEngine;
using System.Collections;

public class Respawner : MonoBehaviour {

    [SerializeField]
    private Transform respawnPoint;

	void OnTriggerEnter(Collider other)
    {
        other.transform.position = respawnPoint.position;
        GameObject.Find("Characters").GetComponent<AudioSource>().Play();
    }
}
