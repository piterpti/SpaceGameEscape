using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lvl2Win : MonoBehaviour {

    [SerializeField]
    private Text interactionText;

    private bool MAYOMA_ENTER = false;
    private bool CATWOMAN_ENTER = false;
    private bool SCIENCIST_ENTER = false;

    private const string NEXT_SCENE = "EndGame";
    
    void Update()
    {
        if (MAYOMA_ENTER && CATWOMAN_ENTER && SCIENCIST_ENTER)
        {
            interactionText.text = "Wciśnij F, aby przejśc dalej";
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene(NEXT_SCENE);
                Cursor.visible = true;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
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
