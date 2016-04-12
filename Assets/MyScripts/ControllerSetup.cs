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

    void Start()
    {
        wowCamera.target = character_sciencist.transform;
        CURRENT_CHARACTER = character_sciencist;
        EnableCharacterControl(character_sciencist);
        DisableCharacterControl(character_mayoma);
        DisableCharacterControl(character_catwoman);
        currentCharacterText.text = "Character: " + Constants.CHARACTER_SCIENTIST;
    }

    void Update()
    {
        GetInput();
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
        }
        if (Input.GetKeyDown("2"))
        {           
            wowCamera.target = character_sciencist.transform;
            CURRENT_CHARACTER = character_sciencist;
            EnableCharacterControl(character_sciencist);
            DisableCharacterControl(character_mayoma);
            DisableCharacterControl(character_catwoman);
            currentCharacterText.text = "Character: " + Constants.CHARACTER_SCIENTIST;
        }
        if (Input.GetKeyDown("3"))
        {           
            wowCamera.target = character_catwoman.transform;
            CURRENT_CHARACTER = character_catwoman;
            EnableCharacterControl(character_catwoman);
            DisableCharacterControl(character_mayoma);
            DisableCharacterControl(character_sciencist);
            currentCharacterText.text = "Character: " + Constants.CHARACTER_CATWOMAN;
        }
    }

    void DisableCharacterControl(GameObject character)
    {
        if (character.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            character.GetComponent<MayomaController>().enabled = false;
            character.GetComponent<MayomaCharacter>().enabled = false;
        }
        else if(character.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST))
        {
            character.GetComponent<SciencistController>().enabled = false;
            character.GetComponent<SciencistCharacter>().enabled = false;
        }
        else if (character.gameObject.name.Equals(Constants.CHARACTER_CATWOMAN))
        {
            character.GetComponent<CatwomanController>().enabled = false;
            character.GetComponent<CatwomanCharacter>().enabled = false;
        }
        character.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        character.GetComponent<Animator>().SetFloat("Forward", 0, 0, Time.deltaTime);
    }

    void EnableCharacterControl(GameObject character)
    {
        if (character.gameObject.name.Equals(Constants.CHARACTER_MAYOMA))
        {
            character.GetComponent<MayomaController>().enabled = true;
            character.GetComponent<MayomaCharacter>().enabled = true;
        }
        else if (character.gameObject.name.Equals(Constants.CHARACTER_SCIENTIST))
        {
            character.GetComponent<SciencistController>().enabled = true;
            character.GetComponent<SciencistCharacter>().enabled = true;
        }
        else if (character.gameObject.name.Equals(Constants.CHARACTER_CATWOMAN))
        {
            character.GetComponent<CatwomanController>().enabled = true;
            character.GetComponent<CatwomanCharacter>().enabled = true;
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
}
