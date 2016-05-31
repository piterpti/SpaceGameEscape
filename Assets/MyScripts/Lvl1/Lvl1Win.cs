﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lvl1Win : MonoBehaviour {

    [SerializeField]
    private Text interactionText;

    private bool MAYOMA_ENTER = false;
    private bool CATWOMAN_ENTER = false;
    private bool SCIENCIST_ENTER = false;

    private const string NEXT_SCENE = "Lvl2";

    void Update()
    {
        if(MAYOMA_ENTER && CATWOMAN_ENTER && SCIENCIST_ENTER)
        {
            interactionText.text = "Press F, to next level";
            if(Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(NEXT_SCENE);
                Cursor.visible = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            Cursor.visible = true;
            GameObject minigame = GameObject.Find("Minigame");
            Destroy(minigame);
            SceneManager.LoadScene(NEXT_SCENE);
        }

    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            MAYOMA_ENTER = true;
        }
        if (other.gameObject.name.Equals(Constants.CHARACTER_CATWOMAN))
        {
            CATWOMAN_ENTER = true;
        }
        if (other.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST))
        {
            SCIENCIST_ENTER = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            MAYOMA_ENTER = false;
        }
        if (other.gameObject.name.Equals(Constants.CHARACTER_CATWOMAN))
        {
            CATWOMAN_ENTER = false;
        }
        if (other.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST))
        {
            SCIENCIST_ENTER = false;
        }
        interactionText.text = "";
    }
       
}
