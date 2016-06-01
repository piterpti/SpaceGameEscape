using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameControl : MonoBehaviour {
    
    public static GameControl control; 
      
    [SerializeField]
    private ComputerHandlerMinigame minigame;
    [SerializeField]
    private FirstMiniGame minigamelvl2;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Text characterText;
    [SerializeField]
    private Text interactionText;
    [SerializeField]
    private Canvas helpCanvas;
    [SerializeField]
    private Text followText;
    [SerializeField]
    private Text objectiveText;

    private static ControllerSetup controllerSetup;
    private static WowCamera wowCamera;

    void Start()
    {        
        controllerSetup = GetComponent<ControllerSetup>();
        wowCamera = mainCamera.GetComponent<WowCamera>();
        helpCanvas.enabled = false;
        Cursor.visible = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            endMiniGame(false);
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            helpCanvas.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            helpCanvas.enabled = false;
        }


    }

    public void openMiniGame()
    {
        controllerSetup.DisableAllCharacters();
        mainCamera.transform.position = new Vector3(-0.09f, -0.47f, -11.5f);
        mainCamera.transform.rotation = Quaternion.identity;
        changeUIStatus(false);
    }

    public void endMiniGame(bool status)
    {
        controllerSetup.EnableCurrentCharacter();
        if (status)
        {
            if (minigame != null)
            {
                minigame.changeDoorHacked();
            }
            else if(minigamelvl2 != null)
            {
                minigamelvl2.ChangeHacked();
            }
        }
        changeUIStatus(true);
    }

    private void changeUIStatus(bool onOff)
    {
        objectiveText.enabled = onOff;
        characterText.enabled = onOff;
        wowCamera.enabled = onOff;
        controllerSetup.enabled = onOff;
        interactionText.enabled = onOff;
        followText.enabled = onOff;
        Cursor.visible = !onOff;
    }

}
