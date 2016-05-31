using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Lvl1Hints : MonoBehaviour {

    [SerializeField]
    private Text objectiveText;

    private string nextTextToDisplay = "";

    private bool firstTime = true;

	void Start () {
	
	}
	
	void Update () {
        GameObject[] chests = GameObject.FindGameObjectsWithTag("ChestToDestroy");
        if(chests.Length < 2 && firstTime)
        {
            setText("Congratulations!");
            setStatus(true, "Now try to go through ventilation");
            firstTime = false;
        }

	}

    public void setText(string toChange)
    {   
        objectiveText.text = toChange;
    }

    public void setStatus(bool isOn, string nextText)
    {
        StartCoroutine(ChangeColor(isOn));
        nextTextToDisplay = nextText;
    }

    IEnumerator ChangeColor(bool isOn)
    {
        if (isOn)
        {
            objectiveText.color = Color.green;
            yield return new WaitForSeconds(5f);
        }
        objectiveText.color = Color.red;
        objectiveText.text = nextTextToDisplay;
    }
}
