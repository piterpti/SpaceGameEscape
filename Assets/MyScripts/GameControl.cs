using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameControl : MonoBehaviour {
    
    public static GameControl control; 
      
    [SerializeField]
    private ComputerHandlerMinigame minigame;
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private Text characterText;
    [SerializeField]
    private Text interactionText;

    private static ControllerSetup controllerSetup;
    private static WowCamera wowCamera;

    void Start()
    {        
        controllerSetup = GetComponent<ControllerSetup>();
        wowCamera = mainCamera.GetComponent<WowCamera>();
        Cursor.visible = false;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            endMiniGame(false);
        }
    }

    public void openMiniGame()
    {
        controllerSetup.DisableAllCharacters();
        controllerSetup.enabled = false;
        wowCamera.enabled = false;
        mainCamera.transform.position = new Vector3(-0.09f, -0.47f, -11.5f);
        mainCamera.transform.rotation = Quaternion.identity;
        characterText.enabled = false;
        interactionText.enabled = false;
        Cursor.visible = true;
    }

    public void endMiniGame(bool status)
    {
        wowCamera.enabled = true;
        controllerSetup.enabled = true;
        controllerSetup.EnableCurrentCharacter();
        if (status)
        {
            minigame.changeDoorHacked();
        }
        characterText.enabled = true;
        interactionText.enabled = true;
        Cursor.visible = false;
    }

}
