using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectiveHandler : MonoBehaviour {

    public static int TASKS_HACK_COMPUTER = 1;
    public static int TASKS_GO_TO_THE_ROOM = 2;
    public static int DESTROY_CHESTS = 3;
    public static int CHESTS_DESTROYED = 4;
    public static int TWO_FLOOR_STAND = 5;
    public static int SECOND_DOORS_OPEN = 6;
    public static int THROUH_CORRIDOR = 7;
    public static int NEXT_SIDE = 8;
    public static int HELP_OTHERS = 9;
    public static int END_GAME = 10;

    private bool temporaryText = false;

    public static Text objectiveText;

    private string[] OBJECTIVES = { "Find way to disable lasers",
                                        "Hack computer to open doors\nat the end of the corridor",
                                        "Go through the corridor",
                                        "Hmm.. Try to destroy this chests!",
                                        "Find 2nd floor like this to open next door!\nLook, doors in the corridor opened",
                                        "Stan on two floors at the same time\n to open doors",
                                        "Go through open doors",
                                        "Try to overcome obstacles and turn it off!",
                                        "Now, try get to the next side",
                                        "Find way to help others",
                                        "Go all characters over doors"
                                                                };
    private string [] GRATZ = { "Congratulations!", "Done!", "Gratz!", "Yeah!", "Good", "Nice!", "Awesome!" };
    private bool taskChange = true;
    private int taskNumber = 0;

	void Start () {
        objectiveText = GameObject.Find("ObjectiveText").GetComponent<Text>();
	}
	
	void Update () {
        if (taskChange)
        {
            objectiveText.text = OBJECTIVES[taskNumber];
            taskChange = false;
        }

        if(temporaryText && Input.GetKeyDown(KeyCode.Escape))
        {
            resumetPreviousText();
            temporaryText = false;
        }
	}

    public void setTempText(string text)
    {
        objectiveText.text = text;
        temporaryText = true;
    }

    public void resumetPreviousText()
    {
        objectiveText.text = OBJECTIVES[taskNumber];
    }

    public void nextTask(int task)
    {
        if (task <= taskNumber)
            return;
        StartCoroutine(showGratz(task));
    }

    IEnumerator showGratz(int nextTask)
    {
        objectiveText.color = Color.green;      
        objectiveText.text = GRATZ[Random.Range(0, GRATZ.Length)];
        yield return new WaitForSeconds(1.5f);
        objectiveText.color = Color.red;
        taskNumber = nextTask;
        taskChange = true;
    }

    private void ChangeObjective()
    {
        ObjectiveHandler handler = GameObject.Find(Constants.GAME_CONTROLLER).GetComponent<ObjectiveHandler>();
        handler.nextTask(ObjectiveHandler.CHESTS_DESTROYED);
    }
    
}
