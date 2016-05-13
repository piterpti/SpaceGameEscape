using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class ControllerSetup : MonoBehaviour
{
    [SerializeField]
    private Text currentCharacterText;
    [SerializeField]
    private GameObject character_mayoma;
    [SerializeField]
    private GameObject character_sciencist;
    [SerializeField]
    private GameObject character_catwoman;
    [SerializeField]
    private WowCamera wowCamera;

    public static GameObject CURRENT_CHARACTER;
    private static bool character_change_available;

    void Start()
    {
        character_change_available = true;
        wowCamera.target = character_sciencist.transform;
        CURRENT_CHARACTER = character_sciencist;
        //set follow target to bot
        character_mayoma.GetComponent<MayomaController>().target = CURRENT_CHARACTER.transform;
        character_sciencist.GetComponent<SciencistController>().target = CURRENT_CHARACTER.transform;
        character_catwoman.GetComponent<CatwomanController>().target = CURRENT_CHARACTER.transform;

        EnableCharacterControl(character_sciencist);
        DisableCharacterControl(character_mayoma);
        DisableCharacterControl(character_catwoman);
        currentCharacterText.text = "Character: " + Constants.CHARACTER_SCIENTIST;
    }

    void Update()
    {
        if (character_change_available)
        {
            GetInput();
        }
        
    }

    void GetInput()
    {
        if (Input.GetKeyDown("1"))
        {            
            wowCamera.target = character_mayoma.transform;
            CURRENT_CHARACTER = character_mayoma;
            EnableCharacterControl(character_mayoma);
            DisableCharacterControl(character_sciencist);
            DisableCharacterControl(character_catwoman);
            currentCharacterText.text = "Character: " + Constants.CHARACTER_MAYOMA;
            //set follow target to bot
            character_catwoman.GetComponent<CatwomanController>().target = CURRENT_CHARACTER.transform;
            character_sciencist.GetComponent<SciencistController>().target = CURRENT_CHARACTER.transform;
        }
        if (Input.GetKeyDown("2"))
        {           
            wowCamera.target = character_sciencist.transform;
            CURRENT_CHARACTER = character_sciencist;
            EnableCharacterControl(character_sciencist);
            DisableCharacterControl(character_mayoma);
            DisableCharacterControl(character_catwoman);
            currentCharacterText.text = "Character: " + Constants.CHARACTER_SCIENTIST;
            //set follow target to bot
            character_mayoma.GetComponent<MayomaController>().target = CURRENT_CHARACTER.transform;
            character_catwoman.GetComponent<CatwomanController>().target = CURRENT_CHARACTER.transform;
        }
        if (Input.GetKeyDown("3"))
        {           
            wowCamera.target = character_catwoman.transform;
            CURRENT_CHARACTER = character_catwoman;
            EnableCharacterControl(character_catwoman);
            DisableCharacterControl(character_mayoma);
            DisableCharacterControl(character_sciencist);
            currentCharacterText.text = "Character: " + Constants.CHARACTER_CATWOMAN;
            //set follow target to bot
            character_mayoma.GetComponent<MayomaController>().target = CURRENT_CHARACTER.transform;
            character_sciencist.GetComponent<SciencistController>().target = CURRENT_CHARACTER.transform;
        }
    }

    void DisableCharacterControl(GameObject character)
    {
        if (character.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            //character.GetComponent<MayomaController>().enabled = false;
            //character.GetComponent<MayomaCharacter>().enabled = false;
            character.GetComponent<MayomaController>().m_manual = false;

        }
        else if(character.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST))
        {
            //character.GetComponent<SciencistController>().enabled = false;
            //character.GetComponent<SciencistCharacter>().enabled = false;
            character.GetComponent<SciencistController>().m_manual = false;
        }
        else if (character.gameObject.name.Equals(Constants.CHARACTER_CATWOMAN))
        {
            //character.GetComponent<CatwomanController>().enabled = false;
            //character.GetComponent<CatwomanCharacter>().enabled = false;
            character.GetComponent<CatwomanController>().m_manual = false;
        }
        character.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        character.GetComponent<Animator>().SetFloat("Forward", 0, 0, Time.deltaTime);
    }

    void EnableCharacterControl(GameObject character)
    {
        if (character.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            //character.GetComponent<MayomaController>().enabled = true;
            //character.GetComponent<MayomaCharacter>().enabled = true;
            character.GetComponent<MayomaController>().m_manual = true;
        }
        else if (character.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST))
        {
            //character.GetComponent<SciencistController>().enabled = true;
            //character.GetComponent<SciencistCharacter>().enabled = true;
            character.GetComponent<SciencistController>().m_manual = true;
        }
        else if (character.gameObject.name.Equals(Constants.CHARACTER_CATWOMAN))
        {
            //character.GetComponent<CatwomanController>().enabled = true;
            //character.GetComponent<CatwomanCharacter>().enabled = true;
            character.GetComponent<CatwomanController>().m_manual = true;
        }
    }

    public void EnableCurrentCharacter()
    {
        DisableAllCharacters();
        EnableCharacterControl(CURRENT_CHARACTER);
    }

    public void DisableAllCharacters()
    {
        DisableCharacterControl(character_mayoma);
        DisableCharacterControl(character_sciencist);
        DisableCharacterControl(character_catwoman);
    }

    public static void EnableCharacterChange()
    {
        character_change_available = true;
    }
    public static void DisableCharacterChange()
    {
        character_change_available = false;
    }
}
